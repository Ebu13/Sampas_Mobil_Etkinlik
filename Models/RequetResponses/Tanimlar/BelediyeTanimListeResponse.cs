using Sampas_Mobil_Etkinlik.Models.DTOs.MisafirIstasyon;
using Sampas_Mobil_Etkinlik.Models.DTOs.Tanimlar;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar
{
    public class BelediyeTanimListeResponse:BaseResponse<List<BelediyeTanimListeDto>>
    {
        public BelediyeTanimListeResponse(List<BelediyeTanimListeDto> data) : base(data)
        {
        }

        public BelediyeTanimListeResponse(string message) : base(message)
        {
        }
    }
}
