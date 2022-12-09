using API.Context;
using API.Models;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Data
{
    public class KostRepositories : GeneralRepository<Kosts> /*<Entity> : IRepository<Entity, int> where Entity : class*/
    {
        MyContext myContext;

        public KostRepositories(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        //public IEnumerable<Entity> Get()
        //{
        //    var data = myContext.Set<Entity>().ToList();
        //    return data;

        //}

        //public Entity GetById(int id)
        //{
        //    var data = myContext.Set<Entity>().Find(id);
        //    return data;
        //}

        //public int Create(Entity entity)
        //{
        //    myContext.Set<Entity>().Add(entity);
        //    var data = myContext.SaveChanges();
        //    return data;
        //}

        //public int Update(Entity entity)
        //{
        //    myContext.Set<Entity>().Update(entity);
        //    var result = myContext.SaveChanges();
        //    return result;
        //}

        //public int Delete(int id)
        //{
        //    var data = GetById(id);
        //    myContext.Set<Entity>().Remove(data);
        //    var result = myContext.SaveChanges();
        //    return result;
        //}
    }
}
