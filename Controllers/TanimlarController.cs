using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar;

namespace Sampas_Mobil_Etkinlik.Controllers
{
    public class TanimlarController : BaseApiController
    {
        private readonly ITanimlarBusiness _business;

        public TanimlarController(ITanimlarBusiness business)
        {
            _business = business;
        }
        [Authorize]
        [HttpGet("GetBelediyeTanimlariListe")]
        public async Task<IActionResult> GetBelediyeTanimlariListe([FromQuery] BelediyeTanimListeRequest request)
        {
            var result = await _business.GetBelediyeTanimlariListe(request);
            return Result(result.Data, result.Success, result.Message);

        }
        [Authorize]
        [HttpGet("GetUnvanTanimlariListe")]
        public async Task<IActionResult> GetUnvanTanimlariListe([FromQuery] UnvanTanimListeRequest request)
        {
            var result = await _business.GetUnvanTanimlariListe(request);
            return Result(result.Data, result.Success, result.Message);

        }
        [Authorize]
        [HttpPost("SaveBelediyeTanim")]
        public async Task<IActionResult> SaveBelediyeTanim([FromBody] BelediyeTanimSaveRequest request)
        {
            var result = await _business.SaveBelediyeTanim(request);
            return Result(result.Data, result.Success, result.Message);

        }
        [Authorize]
        [HttpPost("SaveUnvanTanim")]
        public async Task<IActionResult> SaveUnvanTanim([FromBody] UnvanTanimSaveRequest request)
        {
            var result = await _business.SaveUnvanTanim(request);
            return Result(result.Data, result.Success, result.Message);

        }
        [Authorize]
        [HttpGet("DeleteBelediye")]
        public async Task<IActionResult> DeleteBelediye([FromQuery] BelediyeDeleteRequest request)
        {
            var result = await _business.DeleteBelediye(request);
            return Result(result.Data, result.Success, result.Message);

        }
        [Authorize]
        [HttpGet("DeleteUnvan")]
        public async Task<IActionResult> DeleteUnvan([FromQuery] UnvanDeleteRequest request)
        {
            var result = await _business.DeleteUnvan(request);
            return Result(result.Data, result.Success, result.Message);

        }
    }
}
