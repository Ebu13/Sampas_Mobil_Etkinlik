using Sampas_Mobil_Etkinlik.Models.DTOs;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses
{
    public class LoginResponse:BaseResponse<LoginDto>
    {
        public LoginResponse(LoginDto data) : base(data)
        {
        }

        public LoginResponse(string message) : base(message)
        {
        }
    }
}
