namespace API.Repository.Interface
{
    public interface IRepository<Entity, Key> where Entity : class 
    // Entity sebagai class dan Key sebagai tipe data
    {
        public IEnumerable<Entity> Get();
        public Entity GetById(Key id);

        public int Create(Entity Entiry);
        public int Update(Entity Entiry);
        public int Delete(Key id);
    }
}
