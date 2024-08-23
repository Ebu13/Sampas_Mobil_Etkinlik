using AutoMapper;
using Sampas_Mobil_Etkinlik.Data.Entities.Kullanici;
using Sampas_Mobil_Etkinlik.Models.DTOs.Kullanici;

namespace Sampas_Mobil_Etkinlik.Business.Mapping
{
    public class KullaniciProfile : Profile
    {
        public KullaniciProfile()
        {
            CreateMap<KullaniciListeOutputEntity, KullaniciListeDto>();
        }

    }
}
