using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities.Misafir
{
    public class MisafirSaveOutputEntity
    {
        [Column("MISAFIR_KODU")]
        public int? MisafirKodu { get; set; }
        [Column("SONUC")]
        public short? Sonuc { get; set; }
        [Column("SONUC_ACIKLAMA")]
        public string? SonucAciklama { get; set; }
    }
}
