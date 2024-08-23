using Sampas_Mobil_Etkinlik.Models.DTOs.Istasyon;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon
{
    public class IstasyonAnalizListeResponse : BaseResponse<List<IstasyonAnalizListeDto>>
    {
        public IstasyonAnalizListeResponse(List<IstasyonAnalizListeDto> data) : base(data)
        {
        }

        public IstasyonAnalizListeResponse(string message) : base(message)
        {
        }
    }
}
