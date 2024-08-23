using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using Sampas_Mobil_Etkinlik.Data.Entities;
using Sampas_Mobil_Etkinlik.Data.Entities.MisafirIstasyon;
using Sampas_Mobil_Etkinlik.Data.Repositories.Context;
using Sampas_Mobil_Etkinlik.Data.Repositories.Interfaces;
using Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon;
using System.Data;

namespace Sampas_Mobil_Etkinlik.Data.Repositories
{
    public class MisafirIstasyonRepository : IMisafirIstasyonRepository
    {
        private readonly DapperContext _context;

        public MisafirIstasyonRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<SaveDeleteOutputEntity> DeleteMisafirIstasyon(MisafirIstasyonDeleteRequest request)
        {
            var dbParameters = new OracleDynamicParameters();

            dbParameters.Add("V_KAYIT_NO", request.KayitNo, (OracleMappingType?)OracleDbType.Int64, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.misafir_istasyon_del", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .SingleOrDefault();

                return output;
            }
        }

        public async Task<List<MisafirIstasyonListeOutputEntity>> GetMisafirIstasyonListe(MisafirIstasyonListeRequest request)
        {
            var dbParameters = new OracleDynamicParameters();

            dbParameters.Add("V_MISAFIR_KODU", request.MisafirKodu, (OracleMappingType?)OracleDbType.Int32, ParameterDirection.Input);
            dbParameters.Add("V_ISTASYON_KODU", request.IstasyonKodu, (OracleMappingType?)OracleDbType.Int32, ParameterDirection.Input);
            dbParameters.Add("V_TARIH", request.Tarih, (OracleMappingType?)OracleDbType.Date, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                List<MisafirIstasyonListeOutputEntity> liste = (await connection.QueryAsync<MisafirIstasyonListeOutputEntity>("SMP_ETKINLIK.misafir_istasyon_liste", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .ToList();

                return liste;
            }
        }



        public async Task<SaveDeleteOutputEntity> SaveMisafirIstasyon(MisafirIstasyonSaveRequest request)
        {
            var dbParameters = new OracleDynamicParameters();

            dbParameters.Add("V_MISAFIR_KODU", request.MisafirKodu, (OracleMappingType?)OracleDbType.Int32, ParameterDirection.Input);
            dbParameters.Add("V_ISTASYON_KODU", request.IstasyonKodu, (OracleMappingType?)OracleDbType.Int32, ParameterDirection.Input);
            dbParameters.Add("V_TARIH", request.Tarih, (OracleMappingType?)OracleDbType.Date, ParameterDirection.Input);
            dbParameters.Add("V_RANDEVU_ISTEGI", request.RandevuIstegi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_MISAFIR_YORUMU", request.MisafirYorumu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_SAMPAS_YORUMU", request.SampasYorumu, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("V_KULLANICI_ADI", request.KullaniciAdi, (OracleMappingType?)OracleDbType.Varchar2, ParameterDirection.Input);
            dbParameters.Add("CV_1", dbType: (OracleMappingType?)OracleDbType.RefCursor, direction: ParameterDirection.Output);

            using (var connection = _context.CreateConnection())
            {
                SaveDeleteOutputEntity output = (await connection.QueryAsync<SaveDeleteOutputEntity>("SMP_ETKINLIK.misafir_istasyon_save", param: dbParameters, commandType: CommandType.StoredProcedure))
                    .FirstOrDefault();

                return output;
            }
        }
    }
}
