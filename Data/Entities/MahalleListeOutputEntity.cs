using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities
{
    public class MahalleListeOutputEntity
    {
        [Column("MAHALLE_KODU")]
        public long? MahalleKodu { get; set; }
        [Column("MAHALLE_ADI")]
        public string? MahalleAdi { get; set; }

    }
}
