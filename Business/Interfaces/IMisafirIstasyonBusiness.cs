using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon;

namespace Sampas_Mobil_Etkinlik.Business.Interfaces
{
    public interface IMisafirIstasyonBusiness
    {
        Task<SaveDeleteResponse> SaveMisafirIstasyon(MisafirIstasyonSaveRequest request);
        Task<MisafirIstasyonListeResponse> GetMisafirIstasyonListe(MisafirIstasyonListeRequest request);
        Task<SaveDeleteResponse> DeleteMisafirIstasyon(MisafirIstasyonDeleteRequest request);

    }
}
