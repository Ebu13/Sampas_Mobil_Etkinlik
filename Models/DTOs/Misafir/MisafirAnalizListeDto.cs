namespace Sampas_Mobil_Etkinlik.Models.DTOs.Misafir
{
    public class MisafirAnalizListeDto
    {
        public long? MisafirKodu { get; set; }
        public string? Adi { get; set; }
        public string? Soyadi { get; set; }
        public string? BelediyeAdi { get; set; }
        public string? IstasyonAdlari { get; set; }
        public string? Unvan { get; set; }
        public short? Sonuc { get; set; }
        public string? SonucAciklama { get; set; }
    }
}
