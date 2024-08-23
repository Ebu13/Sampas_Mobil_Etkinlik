using Oracle.ManagedDataAccess.Client;
using Dapper.Oracle;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Repositories.Context;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using System.Data;
using Dapper;

namespace Sampas_Mobil_Etkinlik.Data.Repositories
{
    public class MahalleListeRepository : IMahalleListeRepository
    {
        private readonly DapperContext _context;

        public MahalleListeRepository(DapperContext context)
        {
            _context = context;
        }


        public async Task<List<MahalleListeOutputEntity>> GetMahalleListe(MahalleListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();


            dbParameters.Add("V_BOLGE_KODU", request.BolgeKodu, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);
            dbParameters.Add("V_MAHALLE_KODU", request.MahalleKodu, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {

                List<MahalleListeOutputEntity> output = (await connection.QueryAsync<MahalleListeOutputEntity>("NW_ONLINE_BELEDIYEM.ort_mahalle_search", param: dbParameters, commandType: CommandType.StoredProcedure)
                ).ToList();

                return output;


            }
        }


    }
}
