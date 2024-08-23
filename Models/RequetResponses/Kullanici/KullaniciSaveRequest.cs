using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici
{
    public class KullaniciSaveRequest
    {
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadi { get; set; }
        [Required]
        public string KullaniciKodu { get; set; }
        [Required]
        public string Sifre { get; set; }
        [Required]
        public int IstasyonKodu { get; set; }
        [Required]
        public string YoneticiEH { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
    }
}
