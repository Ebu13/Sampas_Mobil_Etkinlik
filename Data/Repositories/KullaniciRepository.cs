using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.Kullanici;
using Sampas_Mobil_Etkinlik.Data.Repositories.Context;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici;
using System.Data;

namespace Sampas_Mobil_Etkinlik.Data.Repositories
{
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly DapperContext _context;

        public KullaniciRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<SaveDeleteOutputEntity> DeleteKullanici(KullaniciDeleteRequest request)
        {
            var dbParameters = new OracleDynamicParameters();
            dbParameters.Add("V_KULLANICI_KODU", request.KullaniciKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);


            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.kullanici_sil", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();

                return output;
            }
        }

        public async Task<List<KullaniciListeOutputEntity>> GetKullaniciListe(KullaniciListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();


            dbParameters.Add("V_KULLANICI_KODU", request.KullaniciKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                List<KullaniciListeOutputEntity> output = (await connection.QueryAsync<KullaniciListeOutputEntity>("SMP_ETKINLIK.kullanici_liste", param: dbParameters, commandType: CommandType.StoredProcedure)
                ).ToList();

                return output;
            }
        }

        public async Task<SaveDeleteOutputEntity> SaveKullanici(KullaniciSaveRequest request)
        {
            var dbParameters = new OracleDynamicParameters();

            dbParameters.Add("V_ADI", request.Adi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_SOYADI", request.Soyadi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_KULLANICI_KODU", request.KullaniciKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_SIFRE", request.Sifre, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_ISTASYON_KODU", request.IstasyonKodu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_YONETICI_EH", request.YoneticiEH, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_KULLANICI_ADI", request.KullaniciAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.kullanici_save", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();

                return output;
            }
        }
    }
}
