using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar
{
    public class UnvanDeleteRequest
    {
        [Required]
        public long UnvanKodu { get; set; }
    }
}
