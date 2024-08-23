
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;

namespace Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginOutputEntity> LoginKontrol(LoginRequest request);

    }
}
