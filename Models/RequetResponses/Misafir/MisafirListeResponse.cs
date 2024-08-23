using Sampas_Mobil_Etkinlik.Models.DTOs.Misafir;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir
{
    public class MisafirListeResponse : BaseResponse<List<MisafirListeDto>>
    {
        public MisafirListeResponse(List<MisafirListeDto> data) : base(data)
        {
        }

        public MisafirListeResponse(string message) : base(message)
        {
        }
    }
}
