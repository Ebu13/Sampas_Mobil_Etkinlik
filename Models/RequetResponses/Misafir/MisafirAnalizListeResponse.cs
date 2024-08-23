using Sampas_Mobil_Etkinlik.Models.DTOs.Misafir;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir
{
    public class MisafirAnalizListeResponse : BaseResponse<List<MisafirAnalizListeDto>>
    {
        public MisafirAnalizListeResponse(List<MisafirAnalizListeDto> data) : base(data)
        {
        }

        public MisafirAnalizListeResponse(string message) : base(message)
        {
        }
    }
}
