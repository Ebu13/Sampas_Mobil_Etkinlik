using AutoMapper;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.DTOs;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;

namespace Sampas_Mobil_Etkinlik.Business
{
    public class MahalleListeBusiness : IMahalleListeBusiness
    {
        private readonly IMahalleListeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<MahalleListeBusiness> _logger;

        public MahalleListeBusiness(IMahalleListeRepository repository, IMapper mapper, ILogger<MahalleListeBusiness> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MahalleListeResponse> GetMahalleListe(MahalleListeRequest request)
        {
            //_logger.LogInformation("GetMahalleListe işlemi başladı");
            var liste = await _repository.GetMahalleListe(request);
            //_logger.LogInformation("GetMahalleListe işlemi tamamlandı.");

            return new MahalleListeResponse(_mapper.Map<List<MahalleListeDto>>(liste));
        }
    }
}
