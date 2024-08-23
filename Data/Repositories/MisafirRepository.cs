using Dapper.Oracle;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Repositories.Context;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir;
using System.Data;
using Sampas_Mobil_Etkinlik.Data.Entities.Misafir;
using Sampas_Mobil_Etkinlik.Models.RequetResponses;

namespace Sampas_Mobil_Etkinlik.Data.Repositories
{
    public class MisafirRepository : IMisafirRepository
    {
        private readonly DapperContext _context;

        public MisafirRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<SaveDeleteOutputEntity> DeleteMisafir(MisafirDeleteRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_MISAFIR_KODU", request.MisafirKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.misafir_sil", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();

                return output;
            }

        }

        public async Task<List<MisafirAnalizListeOutputEntity>> GetMisafirAnalizListe(AnalizListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_TARIH", request.Tarih, (OracleMappingType?)OracleDbType.Date, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                List<MisafirAnalizListeOutputEntity> output = (await connection.QueryAsync<MisafirAnalizListeOutputEntity>("SMP_ETKINLIK.misafir_analiz_liste", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                return output;
            }
        }

        public async Task<List<MisafirListeOutputEntity>> GetMisafirListe(MisafirListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_ADI", request.Adi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_SOYADI", request.Soyadi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_MISAFIR_KODU", request.MisafirKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_BARKOD_NO", request.BarkodNo, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_PERSONEL_MI", request.PersonelMi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                List<MisafirListeOutputEntity> output = (await connection.QueryAsync<MisafirListeOutputEntity>("SMP_ETKINLIK.misafir_liste", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                return output;
            }
        }

        public async Task<MisafirSaveOutputEntity> SaveMisafir(MisafirSaveOrUpdateRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_ADI", request.Adi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_SOYADI", request.Soyadi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_RF_ETK_BELEDIYE_TANIM", request.BelediyeKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_KULLANICI_ADI", request.KullaniciAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_RF_ETK_UNVAN_TANIM", request.UnvanKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_MISAFIR_KODU", request.MisafirKodu, (OracleMappingType?)OracleDbType.Int32, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                MisafirSaveOutputEntity output = (await connection.QueryAsync<MisafirSaveOutputEntity>("SMP_ETKINLIK.misafir_save", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();

                return output;
            }
        }
    }
}
