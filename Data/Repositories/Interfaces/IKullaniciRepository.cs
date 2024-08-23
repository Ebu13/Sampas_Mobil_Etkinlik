using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.Kullanici;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici;

namespace Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces
{
    public interface IKullaniciRepository
    {
        Task<List<KullaniciListeOutputEntity>> GetKullaniciListe(KullaniciListeRequest request);
        Task<SaveDeleteOutputEntity> SaveKullanici(KullaniciSaveRequest request);
        Task<SaveDeleteOutputEntity> DeleteKullanici(KullaniciDeleteRequest request);

    }
}
