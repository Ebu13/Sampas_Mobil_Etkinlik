using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.Tanimlar;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar;

namespace Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces
{
    public interface ITanimlarRepository
    {
        Task<List<BelediyeTanimListeOutputEntity>> GetBelediyeTanimlariListe(BelediyeTanimListeRequest request);
        Task<List<UnvanTanimListeOutputEntity>> GetUnvanTanimlariListe(UnvanTanimListeRequest request);
        Task<SaveDeleteOutputEntity> SaveBelediyeTanim(BelediyeTanimSaveRequest request);
        Task<SaveDeleteOutputEntity> SaveUnvanTanim(UnvanTanimSaveRequest request);
        Task<SaveDeleteOutputEntity> DeleteUnvan(UnvanDeleteRequest request);
        Task<SaveDeleteOutputEntity> DeleteBelediye(BelediyeDeleteRequest request);

    }
}
