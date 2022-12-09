using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Email{ get; set; }
        public string Tanggal_Lahir{ get; set; }
        public string No_Hp{ get; set; }
        public string Alamat{ get; set; }

        public string Password { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
