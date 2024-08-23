using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon;

namespace Sampas_Mobil_Etkinlik.Controllers
{
    public class IstasyonController : BaseApiController
    {
        private readonly IIstasyonBusiness _business;

        public IstasyonController(IIstasyonBusiness business)
        {
            _business = business;
        }
        [Authorize]
        [HttpGet("GetIstasyonListe")]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> GetIstasyonListe([FromQuery] IstasyonListeRequest request)
        {
            var result = await _business.GetIstasyonListe(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpGet("GetIstasyonAnalizListe")]
        public async Task<IActionResult> GetIstasyonAnalizListe([FromQuery] AnalizListeRequest request)
        {
            var result = await _business.GetIstasyonAnalizListe(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpPost("SaveIstasyon")]

        public async Task<IActionResult> SaveIstasyon([FromBody] IstasyonSaveRequest request)
        {
            var result = await _business.SaveIstasyon(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpGet("DeleteIstasyon")]

        public async Task<IActionResult> DeleteIstasyon([FromQuery] IstasyonDeleteRequest request)
        {
            var result = await _business.DeleteIstasyon(request);
            return Result(result.Data, result.Success, result.Message);
        }

    }
}

