using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Models.DTOs;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;

namespace Sampas_Mobil_Etkinlik.Controllers
{
    public class MahalleListeController : BaseApiController
    {
        private readonly IMahalleListeBusiness _business;
        private readonly IMemoryCache _memoryCache;



        public MahalleListeController(IMahalleListeBusiness business, IMemoryCache memoryCache)
        {

            _business = business;
            _memoryCache = memoryCache;
        }
        [Authorize]
        //[Authorize(Policy = "UyeOrAdmin")]
        [HttpPost]
        ////[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> GetMahalleListe([FromBody] MahalleListeRequest request)
        {
            // Create a unique cache key (adjust based on your request parameters)
            string cacheKey = "MahalleListe_" + "bolge:" + request.BolgeKodu + "_mahalle:" + request.MahalleKodu;

            // Try to fetch from cache
            if (_memoryCache.TryGetValue(cacheKey, out List<MahalleListeDto> cachedResult))
            {
                return Result(cachedResult, true, "Data from cache");
            }

            // Not in cache, get data from the business layer
            var result = await _business.GetMahalleListe(request);

            try
            {
                if (result.Success && result.Data != null)
                {

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(60)); // Adjust expiration

                    _memoryCache.Set(cacheKey, result.Data, cacheEntryOptions);
                }
            }
            catch
            {

                return Result(result.Data, result.Success, result.Message);

            }
            // Store in cache if successful
            return Result(result.Data, result.Success, result.Message);

        }




    }

}
