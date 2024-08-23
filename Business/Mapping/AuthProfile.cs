using AutoMapper;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Models.DTOs;

namespace Sampas_Mobil_Etkinlik.Business.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<LoginOutputEntity, LoginDto>();
        }
    }
}
