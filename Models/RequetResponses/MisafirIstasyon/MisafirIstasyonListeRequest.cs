namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon
{
    public class MisafirIstasyonListeRequest
    {
        public int? MisafirKodu { get; set; }
        public int? IstasyonKodu { get; set; }
        public DateTime? Tarih { get; set; }
    }
}
