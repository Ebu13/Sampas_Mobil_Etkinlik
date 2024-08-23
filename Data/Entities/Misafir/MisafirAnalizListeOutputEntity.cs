using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities.Misafir
{
    public class MisafirAnalizListeOutputEntity
    {
        [Column("MISAFIR_KODU")]
        public long? MisafirKodu { get; set; }
        [Column("ADI")]
        public string? Adi { get; set; }
        [Column("SOYADI")]
        public string? Soyadi { get; set; }
        [Column("BELEDIYE_ADI")]
        public string? BelediyeAdi { get; set; }
        [Column("ISTASYON_ADLARI")]
        public string? IstasyonAdlari { get; set; }
        [Column("UNVAN")]
        public string? Unvan { get; set; }
        [Column("SONUC")]
        public short? Sonuc { get; set; }
        [Column("SONUC_ACIKLAMA")]
        public string? SonucAciklama { get; set; }
    }
}
