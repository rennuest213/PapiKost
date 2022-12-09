using API.Context;
using API.Models;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Client.Controllers
{
    public class KostController : Controller
    {
        MyContext mycontext;
        public KostController(MyContext myContext)
        {
            this.mycontext = myContext;
        }

        public IActionResult Index()
        {
            //var data = mycontext.tb_tr_Kosts.ToList();
            return View();
        }

        // GET BY ID
        public IActionResult Details(int id)
        {
            //var data = mycontext.tb_tr_Kosts.Find(id);
            return View();
        }
        public IActionResult Create()
        {
            // get data disini
            // ex: dropdown data didapat dari database
            //var data = new ViewModelKost();
            //data.tb_tr_Kosts = mycontext.tb_tr_Kosts.Select(a => new SelectListItem()
            //{
            //    Value = a.PemilikID.ToString(),
            //    Text = a.Name
            //}).ToList();
            return View();
        }

        public IActionResult Edit(int id)
        {
            //var data = mycontext.tb_tr_Kosts.Find(id);
            return View();
        }
        public IActionResult Delete(int id)
        {
            //var data = mycontext.tb_tr_Kosts.Find(id);
            return View();
        }


    }
}
