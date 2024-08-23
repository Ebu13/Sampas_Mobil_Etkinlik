using Sampas_Mobil_Etkinlik.Models.DTOs.MisafirIstasyon;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon
{
    public class MisafirIstasyonListeResponse : BaseResponse<List<MisafirIstasyonListeDto>>
    {
        public MisafirIstasyonListeResponse(List<MisafirIstasyonListeDto> data) : base(data)
        {
        }

        public MisafirIstasyonListeResponse(string message) : base(message)
        {
        }
    }
}
