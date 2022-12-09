namespace API.Repositories.Interface
{
    public interface IRepository<Entity, key> where Entity : class
    {

        public IEnumerable<Entity> Get();

        public Entity GetById(key id);

        public int Create(Entity entity);

        public int Update(Entity entity);

        public int Delete(key Id);
    }
}
