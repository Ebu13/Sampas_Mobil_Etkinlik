using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Istasyon
{
    public class IstasyonDeleteRequest
    {
        [Required]
        public int IstasyonKodu { get; set; }
    }
}
