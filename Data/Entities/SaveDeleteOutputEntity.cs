using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities
{
    public class SaveDeleteOutputEntity
    {
        [Column("SONUC")]
        public short? Sonuc { get; set; }
        [Column("SONUC_ACIKLAMA")]
        public string? SonucAciklama { get; set; }
    }
}
