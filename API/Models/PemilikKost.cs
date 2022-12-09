using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class PemilikKost
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string No_Hp { get; set; }
        public string Alamat { get; set; }
    }
}
