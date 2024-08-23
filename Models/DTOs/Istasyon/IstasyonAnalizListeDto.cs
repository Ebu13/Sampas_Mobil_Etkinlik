namespace Sampas_Mobil_Etkinlik.Models.DTOs.Istasyon
{
    public class IstasyonAnalizListeDto
    {
        public int? IstasyonKodu { get; set; }
        public string? IstasyonAdi { get; set; }
        public int? MisafirSayisi { get; set; }
        public short? Sonuc { get; set; }
        public string? SonucAciklama { get; set; }
    }
}
