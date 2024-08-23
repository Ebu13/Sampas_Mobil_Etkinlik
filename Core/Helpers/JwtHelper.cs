using Sampas_Mobil_Etkinlik.Core.Config;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


namespace Sampas_Mobil_Etkinlik.Core.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateJwtToken(JwtSettings jwtSettings, string userName, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(jwtSettings.Secret);

            
            if (userName == null) throw new UnauthorizedAccessException("Kullanıcı adı bulunamadı.");
            
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("un", userName.Encrypt(jwtSettings.EncryptionKey)));
            if (password == null) throw new UnauthorizedAccessException("Şifre bulunamadı.");
            claims.Add(new Claim("psw", password.Encrypt(jwtSettings.EncryptionKey)));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtSettings.Issuer,
                Audience = jwtSettings.Audience,
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
