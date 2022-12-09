using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class KostController : BaseController<KostRepositories, Kosts>
    {
        private KostRepositories kostRepositories;

        public KostController(KostRepositories kostRepositories) : base(kostRepositories)
        {
            this.kostRepositories = kostRepositories;
        }


    }
}
