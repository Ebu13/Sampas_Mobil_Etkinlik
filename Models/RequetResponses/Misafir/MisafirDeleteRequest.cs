using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir
{
    public class MisafirDeleteRequest
    {
        [Required]
        public int MisafirKodu { get; set; }
    }
}
