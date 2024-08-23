using AutoMapper;
using Sampas_Mobil_Etkinlik.Data.Entities.Misafir;
using Sampas_Mobil_Etkinlik.Models.DTOs.Misafir;

namespace Sampas_Mobil_Etkinlik.Business.Mapping
{
    public class MisafirProfile : Profile
    {
        public MisafirProfile()
        {
            CreateMap<MisafirListeOutputEntity, MisafirListeDto>();
            CreateMap<MisafirAnalizListeOutputEntity, MisafirAnalizListeDto>();
            CreateMap<MisafirSaveOutputEntity, MisafirSaveDto>();
        }
    }
}
