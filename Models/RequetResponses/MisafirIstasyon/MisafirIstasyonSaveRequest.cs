using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon
{
    public class MisafirIstasyonSaveRequest
    {
        [Required]
        public int MisafirKodu { get; set; }
        [Required]
        public int IstasyonKodu { get; set; }
        [Required]
        public DateTime Tarih { get; set; }
        public string? RandevuIstegi { get; set; }
        public string? MisafirYorumu { get; set; }
        public string? SampasYorumu { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
    }
}
