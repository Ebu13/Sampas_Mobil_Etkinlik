using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar
{
    public class BelediyeTanimSaveRequest
    {
        
        public long? BelediyeKodu { get; set; }
        [Required]
        public string BelediyeAdi { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
    }
}
