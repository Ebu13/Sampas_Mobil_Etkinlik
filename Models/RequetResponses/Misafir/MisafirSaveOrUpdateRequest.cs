using System.ComponentModel.DataAnnotations;

namespace Sampas_Mobil_Etkinlik.Models.RequetResponses.Misafir
{
    public class MisafirSaveOrUpdateRequest
    {
        public int? MisafirKodu { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public long? BelediyeKodu { get; set; }
        public long? UnvanKodu { get; set; }
        public string KullaniciAdi { get; set; }

    }
}
