using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PemilikKostController : BaseController<PemilikKostRepositories, PemilikKost>
    {
        private PemilikKostRepositories pemilikKostRepositories;
        public PemilikKostController(PemilikKostRepositories pemilikKostRepositories) : base(pemilikKostRepositories)
        {
            this.pemilikKostRepositories = pemilikKostRepositories;
        }
    }
}
