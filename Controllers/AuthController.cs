using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Common.Constants;
using Sampas_Mobil_Etkinlik.Core.Config;
using Sampas_Mobil_Etkinlik.Core.Helpers;
using Sampas_Mobil_Etkinlik.Models;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici;

namespace Sampas_Mobil_Etkinlik.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly AppSettings _appSettings;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthBusiness _business;
        private readonly IKullaniciBusiness _KullaniciBusiness;

        public AuthController(IOptions<AppSettings> appSettings, IOptions<JwtSettings> jwtSettings, ILogger<AuthController> logger, IAuthBusiness business, IKullaniciBusiness kullaniciBusiness)
        {
            _appSettings = appSettings.Value;
            _jwtSettings = jwtSettings.Value;
            _logger = logger;
            _business = business;
            _KullaniciBusiness = kullaniciBusiness;
        }
        
        [HttpPost("LoginControl")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            LoginResponse result = await _business.LoginKontrol(request);
            if (result.Data.Sonuc != 0) return new BadRequestObjectResult(new ApiResponse(ErrorMessages.REQUEST_PARAMETERS_INVALID));
            KullaniciListeResponse result2 = await _KullaniciBusiness.GetKullaniciListe(new KullaniciListeRequest { KullaniciKodu = result.Data.KullaniciKodu });
            result.Data.Adi = result2.Data[0].Adi;
            result.Data.Soyadi = result2.Data[0].Soyadi;
            //result.Data.KullaniciKodu = result2.Data[0].KullaniciKodu;
            result.Data.IstasyonKodu = result2.Data[0].IstasyonKodu;
            result.Data.YoneticiEH = result2.Data[0].YoneticiEh;
            if (result.Success)
            {
                var token = JwtHelper.GenerateJwtToken(_jwtSettings, result.Data.KullaniciKodu, result.Data.Adi+" "+result.Data.Soyadi);
                result.Data.Token =token;
               // Response.Cookies.Append("X-Access-Token", token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None, Secure = true, Expires = DateTime.UtcNow.AddDays(2) });

            }

            return Result(result.Data, result.Success, result.Message);
        }


    }
}
