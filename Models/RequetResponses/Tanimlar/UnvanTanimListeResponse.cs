using Sampas_Mobil_Etkinlik.Models.DTOs.Tanimlar;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar
{
    public class UnvanTanimListeResponse : BaseResponse<List<UnvanTanimListeDto>>
    {
        public UnvanTanimListeResponse(List<UnvanTanimListeDto> data) : base(data)
        {
        }

        public UnvanTanimListeResponse(string message) : base(message)
        {
        }
    }
}
