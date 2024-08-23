namespace Sampas_Mobil_Etkinlik.Core.Config
{
    
        public class JwtSettings
        {
            public string EncryptionKey { get; set; }
            public string Secret { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public int ExpiresInMinutes { get; set; }
        }
    
}
