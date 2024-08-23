using AutoMapper;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.DTOs;
using Sampas_Mobil_Etkinlik.Models.DTOs.MisafirIstasyon;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon;

namespace Sampas_Mobil_Etkinlik.Business
{
    public class MisafirIstasyonBusiness : IMisafirIstasyonBusiness
    {
        private readonly IMisafirIstasyonRepository _repository;
        private readonly IMapper _mapper;

        public MisafirIstasyonBusiness(IMisafirIstasyonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<SaveDeleteResponse> DeleteMisafirIstasyon(MisafirIstasyonDeleteRequest request)
        {
            var output = await _repository.DeleteMisafirIstasyon(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }

        public async Task<MisafirIstasyonListeResponse> GetMisafirIstasyonListe(MisafirIstasyonListeRequest request)
        {
            var output = await _repository.GetMisafirIstasyonListe(request);
            return new MisafirIstasyonListeResponse(_mapper.Map<List<MisafirIstasyonListeDto>>(output));
        }

        public async Task<SaveDeleteResponse> SaveMisafirIstasyon(MisafirIstasyonSaveRequest request)
        {
            var output = await _repository.SaveMisafirIstasyon(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }
    }
}
