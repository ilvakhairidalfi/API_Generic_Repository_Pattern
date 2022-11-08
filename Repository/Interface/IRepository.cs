namespace API.Repository.Interface
{
    public interface IRepository<Entity> where Entity : class 
    // Entity sebagai class dan Key sebagai tipe data
    {
        public IEnumerable<Entity> Get();
        public Entity GetById(int id);

        public int Create(Entity Entity);
        public int Update(Entity Entity);
        public int Delete(int id);
    }
}
