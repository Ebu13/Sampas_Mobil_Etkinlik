using Dapper;
using Dapper.Oracle;

using Oracle.ManagedDataAccess.Client;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Repositories.Context;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using System.Data;

namespace Sampas_Mobil_Etkinlik.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DapperContext _context;

        public AuthRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<LoginOutputEntity> LoginKontrol(LoginRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_KULLANICI_KODU", request.KullaniciKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_SIFRE", request.Sifre, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);
            using (var connection = _context.CreateConnection())
            {
                LoginOutputEntity output = (await connection.QueryAsync<LoginOutputEntity>("SMP_ETKINLIK.log_in_kontrol", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();

                return output;
            }

        }
    }
}
