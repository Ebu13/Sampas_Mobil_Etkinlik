using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon;

namespace Sampas_Mobil_Etkinlik.Business.Interfaces
{
    public interface IIstasyonBusiness
    {
        Task<IstasyonListeResponse> GetIstasyonListe(IstasyonListeRequest request);
        Task<IstasyonAnalizListeResponse> GetIstasyonAnalizListe(AnalizListeRequest request);
        Task<SaveDeleteResponse> SaveIstasyon(IstasyonSaveRequest request);
        Task<SaveDeleteResponse> DeleteIstasyon(IstasyonDeleteRequest request);
    }
}
