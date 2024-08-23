using AutoMapper;
using Sampas_Mobil_Etkinlik.Business.Interfaces;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.DTOs;
using Sampas_Mobil_Etkinlik.Models.DTOs.Kullanici;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici;

namespace Sampas_Mobil_Etkinlik.Business
{
    public class KullaniciBusiness : IKullaniciBusiness
    {
        private readonly IKullaniciRepository _repository;
        private readonly IMapper _mapper;

        public KullaniciBusiness(IKullaniciRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<SaveDeleteResponse> DeleteKullanici(KullaniciDeleteRequest request)
        {
            var output = await _repository.DeleteKullanici(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }

        public async Task<KullaniciListeResponse> GetKullaniciListe(KullaniciListeRequest request)
        {
            var liste = await _repository.GetKullaniciListe(request);
            return new KullaniciListeResponse(_mapper.Map<List<KullaniciListeDto>>(liste));
        }

        public async Task<SaveDeleteResponse> SaveKullanici(KullaniciSaveRequest request)
        {
            var output = await _repository.SaveKullanici(request);
            return new SaveDeleteResponse(_mapper.Map<SaveDeleteDto>(output));
        }
    }
}
