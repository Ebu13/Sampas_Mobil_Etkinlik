using Dapper.Oracle;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.Misafir;
using Sampas_Mobil_Etkinlik.Data.Entities.Tanimlar;
using Sampas_Mobil_Etkinlik.Data.Repositories.Context;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar;
using System.Data;

namespace Sampas_Mobil_Etkinlik.Data.Repositories
{
    public class TanimlarRepository : ITanimlarRepository
    {
        private readonly DapperContext _context;

        public TanimlarRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<SaveDeleteOutputEntity> DeleteBelediye(BelediyeDeleteRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_BELEDIYE_KODU", request.BelediyeKodu, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.belediye_sil", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .SingleOrDefault();
                return output;
            }
        }

        public async Task<SaveDeleteOutputEntity> DeleteUnvan(UnvanDeleteRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_UNVAN_KODU", request.UnvanKodu, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.unvan_sil", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .SingleOrDefault();
                return output;
            }
        }

        public async Task<List<BelediyeTanimListeOutputEntity>> GetBelediyeTanimlariListe(BelediyeTanimListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_BELEDIYE_ADI", request.BelediyeAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                List<BelediyeTanimListeOutputEntity> output = (await connection.QueryAsync<BelediyeTanimListeOutputEntity>("SMP_ETKINLIK.belediye_liste", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                return output;
            }
        }

        public async Task<List<UnvanTanimListeOutputEntity>> GetUnvanTanimlariListe(UnvanTanimListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_UNVAN_ADI", request.UnvanAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                List<UnvanTanimListeOutputEntity> output = (await connection.QueryAsync<UnvanTanimListeOutputEntity>("SMP_ETKINLIK.unvan_liste", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                return output;
            }
        }

        public async Task<SaveDeleteOutputEntity> SaveBelediyeTanim(BelediyeTanimSaveRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_BELEDIYE_KODU", request.BelediyeKodu, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);
            dbParameters.Add("V_BELEDIYE_ADI", request.BelediyeAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_KULLANICI_ADI", request.KullaniciAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.belediye_tanim_save", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .SingleOrDefault();

                return output;
            }
        }

        public async Task<SaveDeleteOutputEntity> SaveUnvanTanim(UnvanTanimSaveRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_UNVAN_KODU", request.UnvanKodu, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);
            dbParameters.Add("V_UNVAN_ADI", request.UnvanAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_KULLANICI_ADI", request.KullaniciAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.unvan_tanim_save", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .SingleOrDefault();

                return output;
            }
        }
    }
}
