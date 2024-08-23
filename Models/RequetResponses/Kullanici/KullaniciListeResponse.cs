using Sampas_Mobil_Etkinlik.Models.DTOs.Kullanici;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici
{
    public class KullaniciListeResponse : BaseResponse<List<KullaniciListeDto>>
    {
        public KullaniciListeResponse(List<KullaniciListeDto> data) : base(data)
        {
        }

        public KullaniciListeResponse(string message) : base(message)
        {
        }
    }
}
