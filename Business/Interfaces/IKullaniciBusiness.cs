using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici;

namespace Sampas_Mobil_Etkinlik.Business.Interfaces
{
    public interface IKullaniciBusiness
    {
        Task<KullaniciListeResponse> GetKullaniciListe(KullaniciListeRequest request);
        Task<SaveDeleteResponse> SaveKullanici(KullaniciSaveRequest request);
        Task<SaveDeleteResponse> DeleteKullanici(KullaniciDeleteRequest request);

    }
}
