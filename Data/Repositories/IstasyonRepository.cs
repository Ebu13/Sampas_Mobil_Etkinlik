using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.Istasyon;
using Sampas_Mobil_Etkinlik.Data.Repositories.Context;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon;
using System.Data;

namespace Sampas_Mobil_Etkinlik.Data.Repositories
{
    public class IstasyonRepository : IIstasyonRepository
    {
        private readonly DapperContext _context;

        public IstasyonRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<SaveDeleteOutputEntity> DeleteIstasyon(IstasyonDeleteRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_ISTASYON_KODU", request.IstasyonKodu, (OracleMappingType?)OracleDbType.Int32, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.istasyon_sil", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();

                return output;
            }
        }

        public async Task<List<IstasyonAnalizListeOutputEntity>> GetIstasyonAnalizListe(AnalizListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();


            dbParameters.Add("V_TARIH", request.Tarih, (OracleMappingType?)OracleDbType.Date, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                List<IstasyonAnalizListeOutputEntity> output = (await connection.QueryAsync<IstasyonAnalizListeOutputEntity>("SMP_ETKINLIK.istasyon_analiz_liste", param: dbParameters, commandType: CommandType.StoredProcedure)
                ).ToList();

                return output;
            }
        }

        public async Task<List<IstasyonListeOutputEntity>> GetIstasyonListe(IstasyonListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();


            dbParameters.Add("V_ISTASYON_KODU", request.IstasyonKodu, (OracleMappingType?)OracleDbType.Int32, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                List<IstasyonListeOutputEntity> output = (await connection.QueryAsync<IstasyonListeOutputEntity>("SMP_ETKINLIK.istasyon_liste", param: dbParameters, commandType: CommandType.StoredProcedure)
                ).ToList();

                return output;
            }
        }

        public async Task<SaveDeleteOutputEntity> SaveIstasyon(IstasyonSaveRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_ISTASYON_KODU", request.IstasyonKodu, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);
            dbParameters.Add("V_ISTASYON_ADI", request.IstasyonAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_KULLANICI_ADI", request.KullaniciAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.istasyon_save", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();

                return output;
            }
        }
    }
}
