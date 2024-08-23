using Sampas_Mobil_Etkinlik.Models.RequetResponses;

namespace Sampas_Mobil_Etkinlik.Business.Interfaces
{
    public interface IMahalleListeBusiness
    {
        Task<MahalleListeResponse> GetMahalleListe(MahalleListeRequest request);
    }
}
