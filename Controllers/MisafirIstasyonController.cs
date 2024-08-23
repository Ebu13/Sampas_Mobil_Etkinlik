using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon;

namespace Sampas_Mobil_Etkinlik.Controllers
{
    public class MisafirIstasyonController : BaseApiController
    {
        private readonly IMisafirIstasyonBusiness _business;

        public MisafirIstasyonController(IMisafirIstasyonBusiness business)
        {
            _business = business;
        }
        [Authorize]
        [HttpPost("SaveMisafirIstasyon")]
        public async Task<IActionResult> SaveKullanici([FromBody] MisafirIstasyonSaveRequest request)
        {
            var result = await _business.SaveMisafirIstasyon(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpGet("GetMisafirIstasyonListe")]
        public async Task<IActionResult> GetMisafirIstasyonListe([FromQuery] MisafirIstasyonListeRequest request)
        {
            var result = await _business.GetMisafirIstasyonListe(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpGet("DeleteMisafirIstasyon")]
        public async Task<IActionResult> DeleteMisafirIstasyon([FromQuery] MisafirIstasyonDeleteRequest request)
        {
            var result = await _business.DeleteMisafirIstasyon(request);
            return Result(result.Data, result.Success, result.Message);
        }
    }
}
