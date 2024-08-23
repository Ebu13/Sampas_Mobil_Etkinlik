using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar;

namespace Sampas_Mobil_Etkinlik.Business.Interfaces
{
    public interface ITanimlarBusiness
    {
        Task<BelediyeTanimListeResponse> GetBelediyeTanimlariListe(BelediyeTanimListeRequest request);
        Task<UnvanTanimListeResponse> GetUnvanTanimlariListe(UnvanTanimListeRequest request);
        Task<SaveDeleteResponse> SaveBelediyeTanim(BelediyeTanimSaveRequest request);
        Task<SaveDeleteResponse> SaveUnvanTanim(UnvanTanimSaveRequest request);
        Task<SaveDeleteResponse> DeleteUnvan(UnvanDeleteRequest request);
        Task<SaveDeleteResponse> DeleteBelediye(BelediyeDeleteRequest request);

    }
}
