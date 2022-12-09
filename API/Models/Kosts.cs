using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Kosts
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Harga {get; set; }
        public string Jenis { get; set; }
        public string Alamat { get; set; }
        public string Spesifikasi { get; set; }
        public string Keterangan { get; set; }
        public string Image { get; set; }

        [ForeignKey("PemilikKost")]
        public int PemilikID { get; set; }
        [JsonIgnore]
        public PemilikKost? PemilikKost { get; set; }
    }
}
