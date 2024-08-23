using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.MisafirIstasyon
{
    public class MisafirIstasyonDeleteRequest
    {
        [Required]
        public long KayitNo { get; set; }
    }
}
