using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities.Tanimlar
{
    public class UnvanTanimListeOutputEntity
    {
        [Column("UNVAN_KODU")]
        public long? UnvanKodu { get; set; }
        [Column("UNVAN_ADI")]
        public string UnvanAdi { get; set; }
    }
}
