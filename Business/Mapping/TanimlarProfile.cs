using AutoMapper;
using Sampas_Mobil_Etkinlik.Data.Entities.Tanimlar;
using Sampas_Mobil_Etkinlik.Models.DTOs.Tanimlar;

namespace Sampas_Mobil_Etkinlik.Business.Mapping
{
    public class TanimlarProfile : Profile
    {
        public TanimlarProfile()
        {
            CreateMap<BelediyeTanimListeOutputEntity, BelediyeTanimListeDto>();
            CreateMap<UnvanTanimListeOutputEntity, UnvanTanimListeDto>();            
        }
    }
}
