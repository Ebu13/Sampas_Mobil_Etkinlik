using System.ComponentModel.DataAnnotations.Schema;

namespace Sampas_Mobil_Etkinlik.Data.Entities.Tanimlar
{
    public class BelediyeTanimListeOutputEntity
    {
        [Column("BELEDIYE_KODU")]
        public long? BelediyeKodu { get; set; }
        [Column("BELEDIYE_ADI")]
        public string BelediyeAdi { get; set; }
    }
}
