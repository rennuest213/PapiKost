using Microsoft.AspNetCore.Mvc.Rendering;

namespace API.Models
{
    public class ViewModelKost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PemilikID { get; set; }
        public List<SelectListItem> tb_tr_Kosts { get; set; }
    }
}
