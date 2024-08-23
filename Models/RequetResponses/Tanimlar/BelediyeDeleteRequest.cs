using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Tanimlar
{
    public class BelediyeDeleteRequest
    {
        [Required]
        public long BelediyeKodu { get; set; }
    }
}
