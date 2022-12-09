using API.Context;
using API.Models;

namespace API.Repositories.Data
{
    public class PemilikKostRepositories : GeneralRepository<PemilikKost>
    {
        MyContext myContext;

        public PemilikKostRepositories(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

    }
}
