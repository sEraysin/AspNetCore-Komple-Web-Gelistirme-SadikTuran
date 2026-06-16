using System.ComponentModel.DataAnnotations;

namespace EfcoreApp.Data
{
    public class Kurs
    {
        public int KursId { get; set; }
        [Required]
        public string? Baslik { get; set; }

        public int OgretmenId { get; set; }
        public Ogretmen? Ogretmen { get; set; } = null!;

        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}