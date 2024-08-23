using AutoMapper;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Models.DTOs;

namespace Sampas_Mobil_Etkinlik.Business.Mapping
{
    public class MahalleListeProfile : Profile
    {
        public MahalleListeProfile()
        {
            CreateMap<MahalleListeOutputEntity, MahalleListeDto>();
        }
    }
}
