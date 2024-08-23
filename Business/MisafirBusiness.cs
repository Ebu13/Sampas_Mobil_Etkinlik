using AutoMapper;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.DTOs;
using Sampas_Mobil_Etkinlik.Models.DTOs.Misafir;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir;

namespace Sampas_Mobil_Etkinlik.Business
{
    public class MisafirBusiness : IMisafirBusiness
    {
        private readonly IMisafirRepository _repository;
        private readonly IMapper _mapper;

        public MisafirBusiness(IMisafirRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<SaveDeleteResponse> DeleteMisafir(MisafirDeleteRequest request)
        {
            var output = await _repository.DeleteMisafir(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }

        public async Task<MisafirAnalizListeResponse> GetMisafirAnalizListe(AnalizListeRequest request)
        {
            var output = await _repository.GetMisafirAnalizListe(request);
            return new MisafirAnalizListeResponse(_mapper.Map<List<MisafirAnalizListeDto>>(output));
        }

        public async Task<MisafirListeResponse> GetMisafirListe(MisafirListeRequest request)
        {
            var output = await _repository.GetMisafirListe(request);
            return new MisafirListeResponse(_mapper.Map<List<MisafirListeDto>>(output));
        }

        public async Task<MisafirSaveResponse> SaveMisafir(MisafirSaveOrUpdateRequest request)
        {
            var output = await _repository.SaveMisafir(request);
            return new MisafirSaveResponse(_mapper.Map<MisafirSaveDto>(output));
        }
    }
}
