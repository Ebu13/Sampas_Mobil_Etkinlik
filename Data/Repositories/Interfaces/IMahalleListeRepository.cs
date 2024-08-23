using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;

namespace Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces
{
    public interface IMahalleListeRepository
    {
        Task<List<MahalleListeOutputEntity>> GetMahalleListe(MahalleListeRequest request);
    }
}
