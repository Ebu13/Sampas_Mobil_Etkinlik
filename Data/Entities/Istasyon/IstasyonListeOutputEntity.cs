using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities.Istasyon
{
    public class IstasyonListeOutputEntity
    {
        [Column("ISTASYON_KODU")]
        public int? IstasyonKodu { get; set; }
        [Column("ISTASYON_ADI")]
        public string? IstasyonAdi { get; set; }
        [Column("SONUC")]
        public short? Sonuc { get; set; }
        [Column("SONUC_ACIKLAMA")]
        public string? SonucAciklama { get; set; }
    }
}
