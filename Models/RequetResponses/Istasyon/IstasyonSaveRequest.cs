using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon
{
    public class IstasyonSaveRequest
    {
        public long? IstasyonKodu { get; set; }
        [Required]
        public string IstasyonAdi { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
        
    }
}
