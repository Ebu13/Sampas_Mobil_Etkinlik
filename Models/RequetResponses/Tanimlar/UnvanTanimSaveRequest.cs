using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar
{
    public class UnvanTanimSaveRequest
    {
        
        public long? UnvanKodu { get; set; }
        [Required]
        public string UnvanAdi { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
    }
}
