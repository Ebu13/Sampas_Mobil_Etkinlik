using Sampas_Mobil_Etkinlik.Models.DTOs.Istasyon;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon
{
    public class IstasyonListeResponse : BaseResponse<List<IstasyonListeDto>>
    {
        public IstasyonListeResponse(List<IstasyonListeDto> data) : base(data)
        {
        }

        public IstasyonListeResponse(string message) : base(message)
        {
        }
    }
}
