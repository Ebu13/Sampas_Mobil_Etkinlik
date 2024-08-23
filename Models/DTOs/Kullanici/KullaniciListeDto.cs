namespace Sampas_Mobil_Etkinlik.Models.DTOs.Kullanici
{
    public class KullaniciListeDto
    {
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public int? IstasyonKodu { get; set; }
        public string? KullaniciKodu { get; set; }
        public string? YoneticiEh { get; set; }
        public string? Sifre { get; set; }
        public short? Sonuc { get; set; }
        public string? SonucAciklama { get; set; }
    }
}
