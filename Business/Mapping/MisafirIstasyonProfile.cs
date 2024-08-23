using AutoMapper;
using Sampas_Mobil_Etkinlik.Data.Entities.MisafirIstasyon;
using Sampas_Mobil_Etkinlik.Models.DTOs.MisafirIstasyon;

namespace Sampas_Mobil_Etkinlik.Business.Mapping
{
    public class MisafirIstasyonProfile:Profile
    {
        public MisafirIstasyonProfile()
        {
            CreateMap<MisafirIstasyonListeOutputEntity,MisafirIstasyonListeDto>();
        }
    }
}
