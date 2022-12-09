﻿using API.Context;
using API.Repositories.Interface;


namespace API.Repositories
{
    public class GeneralRepository<Entity> : IRepository<Entity, int> where Entity : class
    {
        MyContext myContext;
        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public IEnumerable<Entity> Get()
        {
            var data = myContext.Set<Entity>().ToList();
            return data;

        }

        public Entity GetById(int id)
        {
            var data = myContext.Set<Entity>().Find(id);
            return data;
        }

        public int Create(Entity entity)
        {
            myContext.Set<Entity>().Add(entity);
            var data = myContext.SaveChanges();
            return data;
        }

        public int Update(Entity entity)
        {
            myContext.Set<Entity>().Update(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = GetById(id);
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }


    }
}
