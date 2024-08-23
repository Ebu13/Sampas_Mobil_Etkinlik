using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Kullanici
{
    public class KullaniciDeleteRequest
    {
        [Required]
        public string KullaniciKodu { get; set; }
    }
}
