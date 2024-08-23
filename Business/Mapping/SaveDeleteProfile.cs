using AutoMapper;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Models.DTOs;

namespace Sampas_Mobil_Etkinlik.Business.Mapping
{
    public class SaveDeleteProfile : Profile
    {
        public SaveDeleteProfile()
        {
            CreateMap<SaveDeleteOutputEntity, SaveDeleteDto>();
        }
    }
}
