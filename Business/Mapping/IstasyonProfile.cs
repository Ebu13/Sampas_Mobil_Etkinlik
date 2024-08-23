using AutoMapper;
using Sampas_Mobil_Etkinlik.Data.Entities.Istasyon;
using Sampas_Mobil_Etkinlik.Models.DTOs.Istasyon;

namespace Sampas_Mobil_Etkinlik.Business.Mapping
{
    public class IstasyonProfile : Profile
    {
        public IstasyonProfile()
        {
            CreateMap<IstasyonListeOutputEntity, IstasyonListeDto>();
            CreateMap<IstasyonAnalizListeOutputEntity, IstasyonAnalizListeDto>();
        }
    }
}
