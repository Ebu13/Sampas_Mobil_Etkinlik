using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities.MisafirIstasyon
{
    public class MisafirIstasyonListeOutputEntity
    {
        [Column("KAYIT_NO")]
        public long? KayitNo { get; set; }
        [Column("ADI")]
        public string? Adi { get; set; }
        [Column("SOYADI")]
        public string? Soyadi { get; set; }
        [Column("BELEDIYE_ADI")]
        public string? BelediyeAdi { get; set; }
        [Column("UNVAN")]
        public string? Unvan { get; set; }
        [Column("TARIH")]
        public DateTime? Tarih { get; set; }
        [Column("RANDEVU_ISTEGI")]
        public string? RandevuIstegi { get; set; }
        [Column("ISTASYON_ADI")]
        public string? IstasyonAdi { get; set; }
        [Column("ISTASYON_KODU")]
        public int? IstasyonKodu { get; set; }
        [Column("MISAFIR_KODU")]
        public int? MisafirKodu { get; set; }
        [Column("MISAFIR_YORUMU")]
        public string? MisafirYorumu { get; set; }
        [Column("SAMPAS_YORUMU")]
        public string? SampasYorumu { get; set; }
        [Column("SONUC")]
        public short? Sonuc { get; set; }
        [Column("SONUC_ACIKLAMA")]
        public string? SonucAciklama { get; set; }
    }
}
