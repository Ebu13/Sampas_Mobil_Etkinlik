namespace Sampas_Mobil_Etkinlik.Models.DTOs.MisafirIstasyon
{
    public class MisafirIstasyonListeDto
    {
        public long? KayitNo { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public string? BelediyeAdi { get; set; }
        public string? Unvan { get; set; }
        public DateTime? Tarih { get; set; }
        public string? RandevuIstegi { get; set; }
        public string? IstasyonAdi { get; set; }
        public int? IstasyonKodu { get; set; }
        public int? MisafirKodu { get; set; }
        public string? MisafirYorumu { get; set; }
        public string? SampasYorumu { get; set; }
        public short? Sonuc { get; set; }
        public string? SonucAciklama { get; set; }
    }
}
