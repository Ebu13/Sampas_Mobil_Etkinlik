using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.Istasyon;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon;

namespace Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces
{
    public interface IIstasyonRepository
    {
        Task<List<IstasyonListeOutputEntity>> GetIstasyonListe(IstasyonListeRequest request);
        Task<List<IstasyonAnalizListeOutputEntity>> GetIstasyonAnalizListe(AnalizListeRequest request);
        Task<SaveDeleteOutputEntity> SaveIstasyon(IstasyonSaveRequest request);
        Task<SaveDeleteOutputEntity> DeleteIstasyon(IstasyonDeleteRequest request);
    }
}
