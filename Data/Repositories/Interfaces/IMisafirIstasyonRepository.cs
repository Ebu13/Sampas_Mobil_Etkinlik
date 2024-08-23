using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.MisafirIstasyon;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon;

namespace Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces
{
    public interface IMisafirIstasyonRepository
    {
        Task<SaveDeleteOutputEntity> SaveMisafirIstasyon(MisafirIstasyonSaveRequest request);
        Task<List<MisafirIstasyonListeOutputEntity>> GetMisafirIstasyonListe(MisafirIstasyonListeRequest request);
        Task<SaveDeleteOutputEntity> DeleteMisafirIstasyon(MisafirIstasyonDeleteRequest request);
    }
}
