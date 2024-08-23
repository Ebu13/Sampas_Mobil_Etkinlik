using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sampas_Mobil_Etkinlik.Business.Interfaces;

using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici;

namespace Sampas_Mobil_Etkinlik.Controllers
{
    public class KullaniciController : BaseApiController
    {
        private readonly IKullaniciBusiness _business;


        public KullaniciController(IKullaniciBusiness business)
        {
            _business = business;

        }

        [Authorize]
        [HttpGet("GetKullaniciListe")]
        //[ResponseCache(Duration = 10, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> GetKullaniciListe([FromQuery] KullaniciListeRequest request)
        {
            var result = await _business.GetKullaniciListe(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpPost("SaveKullanici")]
        public async Task<IActionResult> SaveKullanici([FromBody] KullaniciSaveRequest request)
        {

            var result = await _business.SaveKullanici(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpGet("DeleteKullanici")]
        public async Task<IActionResult> DeleteKullanici([FromQuery] KullaniciDeleteRequest request)
        {
            var result = await _business.DeleteKullanici(request);
            return Result(result.Data, result.Success, result.Message);
        }
    }
}
