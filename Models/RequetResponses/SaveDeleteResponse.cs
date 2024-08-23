using Sampas_Mobil_Etkinlik.Models.DTOs;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses
{
    public class SaveDeleteResponse : BaseResponse<SaveDeleteDto>
    {
        public SaveDeleteResponse(SaveDeleteDto data) : base(data)
        {
        }

        public SaveDeleteResponse(string message) : base(message)
        {
        }
    }
}
