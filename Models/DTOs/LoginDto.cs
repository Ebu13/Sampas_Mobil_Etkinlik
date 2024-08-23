namespace Sampas_Mobil_Etkinlik.Models.DTOs
{
    public class LoginDto
    {
        public string? KullaniciKodu { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public string? YoneticiEH { get; set; }
        public int? IstasyonKodu { get; set; }
        public short? Sonuc { get; set; }
        public string? SonucAciklama { get; set; }
        public string Token { get; set; }
    }
}
