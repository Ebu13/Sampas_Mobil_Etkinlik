using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities.Kullanici
{
    public class KullaniciListeOutputEntity
    {
        [Column("ADI")]
        public string? Adi { get; set; }
        [Column("SOYADI")]
        public string? Soyadi { get; set; }
        [Column("ISTASYON_KODU")]
        public int? IstasyonKodu { get; set; }
        [Column("KULLANICI_KODU")]
        public string? KullaniciKodu { get; set; }
        [Column("YONETICI_EH")]
        public string? YoneticiEh { get; set; }
        [Column("SIFRE")]
        public string? Sifre { get; set; }
        [Column("SONUC")]
        public short? Sonuc { get; set; }
        [Column("SONUC_ACIKLAMA")]
        public string? SonucAciklama { get; set; }
    }
}
