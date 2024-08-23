using Sampas_Mobil_Etkinlik.Models.DTOs.Misafir;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir
{
    public class MisafirSaveResponse : BaseResponse<MisafirSaveDto>
    {
        public MisafirSaveResponse(MisafirSaveDto data) : base(data)
        {
        }

        public MisafirSaveResponse(string message) : base(message)
        {
        }
    }
}
