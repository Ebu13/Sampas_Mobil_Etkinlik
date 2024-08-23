using AutoMapper;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.DTOs;
using Sampas_Mobil_Etkinlik.Models.DTOs.Istasyon;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon;

namespace Sampas_Mobil_Etkinlik.Business
{
    public class IstasyonBusiness : IIstasyonBusiness
    {
        private readonly IIstasyonRepository _repository;
        private readonly IMapper _mapper;

        public IstasyonBusiness(IIstasyonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<SaveDeleteResponse> DeleteIstasyon(IstasyonDeleteRequest request)
        {
            var output = await _repository.DeleteIstasyon(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }

        public async Task<IstasyonAnalizListeResponse> GetIstasyonAnalizListe(AnalizListeRequest request)
        {
            var liste = await _repository.GetIstasyonAnalizListe(request);
            return new IstasyonAnalizListeResponse(_mapper.Map<List<IstasyonAnalizListeDto>>(liste));
        }

        public async Task<IstasyonListeResponse> GetIstasyonListe(IstasyonListeRequest request)
        {
            var liste = await _repository.GetIstasyonListe(request);
            return new IstasyonListeResponse(_mapper.Map<List<IstasyonListeDto>>(liste));
        }

        public async Task<SaveDeleteResponse> SaveIstasyon(IstasyonSaveRequest request)
        {
            var output = await _repository.SaveIstasyon(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }
    }
}
