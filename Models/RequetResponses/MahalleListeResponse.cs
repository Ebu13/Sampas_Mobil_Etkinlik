using Sampas_Mobil_Etkinlik.Models.DTOs;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses
{
    public class MahalleListeResponse : BaseResponse<List<MahalleListeDto>>
    {
        public MahalleListeResponse(List<MahalleListeDto> data) : base(data)
        {
        }

        public MahalleListeResponse(string message) : base(message)
        {
        }
    }
}
