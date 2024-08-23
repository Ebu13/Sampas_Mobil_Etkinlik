using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.Misafir;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir;

namespace Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces
{
    public interface IMisafirRepository
    {
        Task<MisafirSaveOutputEntity> SaveMisafir(MisafirSaveOrUpdateRequest request);
        Task<SaveDeleteOutputEntity> DeleteMisafir(MisafirDeleteRequest request);
        Task<List<MisafirListeOutputEntity>> GetMisafirListe(MisafirListeRequest request);
        Task<List<MisafirAnalizListeOutputEntity>> GetMisafirAnalizListe(AnalizListeRequest request);
    }
}
