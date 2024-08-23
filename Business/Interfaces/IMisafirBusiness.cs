using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir;

namespace Sampas_Mobil_Etkinlik.Business.Interfaces
{
    public interface IMisafirBusiness
    {
        Task<MisafirSaveResponse> SaveMisafir(MisafirSaveOrUpdateRequest request);
        Task<SaveDeleteResponse> DeleteMisafir(MisafirDeleteRequest request);
        Task<MisafirListeResponse> GetMisafirListe(MisafirListeRequest request);
        Task<MisafirAnalizListeResponse> GetMisafirAnalizListe(AnalizListeRequest request);
    }
}
