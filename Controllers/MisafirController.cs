using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir;

namespace Sampas_Mobil_Etkinlik.Controllers
{
    public class MisafirController : BaseApiController
    {
        private readonly IMisafirBusiness _business;

        public MisafirController(IMisafirBusiness business)
        {
            _business = business;
        }
        [Authorize]
        [HttpPost("SaveOrUpdateMisafir")]
        public async Task<IActionResult> SaveMisafir([FromBody] MisafirSaveOrUpdateRequest request)
        {
            var result = await _business.SaveMisafir(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpGet("DeleteMisafir")]
        public async Task<IActionResult> DeleteMisafir([FromQuery] MisafirDeleteRequest request)
        {
            var result = await _business.DeleteMisafir(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpGet("GetMisafirListe")]
        public async Task<IActionResult> GetMisafirListe([FromQuery] MisafirListeRequest request)
        {
            var result = await _business.GetMisafirListe(request);
            return Result(result.Data, result.Success, result.Message);
        }
        [Authorize]
        [HttpGet("GetMisafirAnalizListe")]
        public async Task<IActionResult> GetMisafirAnalizListe([FromQuery] AnalizListeRequest request)
        {
            var result = await _business.GetMisafirAnalizListe(request);
            return Result(result.Data, result.Success, result.Message);
        }
    }
}
