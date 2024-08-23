using AutoMapper;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.DTOs;
using Sampas_Mobil_Etkinlik.Models.DTOs.Tanimlar;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar;

namespace Sampas_Mobil_Etkinlik.Business
{
    public class TanimlarBusiness : ITanimlarBusiness
    {
        private readonly ITanimlarRepository _repository;
        private readonly IMapper _mapper;

        public TanimlarBusiness(ITanimlarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SaveDeleteResponse> DeleteBelediye(BelediyeDeleteRequest request)
        {
            var output = await _repository.DeleteBelediye(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));

        }

        public async Task<SaveDeleteResponse> DeleteUnvan(UnvanDeleteRequest request)
        {
            var output = await _repository.DeleteUnvan(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));

        }

        public async Task<BelediyeTanimListeResponse> GetBelediyeTanimlariListe(BelediyeTanimListeRequest request)
        {
            var output = await _repository.GetBelediyeTanimlariListe(request);
            return new BelediyeTanimListeResponse(_mapper.Map<List<BelediyeTanimListeDto>>(output));
        }

        public async Task<UnvanTanimListeResponse> GetUnvanTanimlariListe(UnvanTanimListeRequest request)
        {
            var output = await _repository.GetUnvanTanimlariListe(request);
            return new UnvanTanimListeResponse(_mapper.Map<List<UnvanTanimListeDto>>(output));
        }

        public async Task<SaveDeleteResponse> SaveBelediyeTanim(BelediyeTanimSaveRequest request)
        {
            var output = await _repository.SaveBelediyeTanim(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }

        public async Task<SaveDeleteResponse> SaveUnvanTanim(UnvanTanimSaveRequest request)
        {
            var output = await _repository.SaveUnvanTanim(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }
    }
}
