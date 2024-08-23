using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Models.DTOs.Misafir
{
    public class MisafirSaveDto
    {
        public int? MisafirKodu { get; set; }
        public short? Sonuc { get; set; }
        public string? SonucAciklama { get; set; }
    }
}
