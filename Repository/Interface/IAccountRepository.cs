namespace API.Repository.Interface
{
    public interface IAccountRepository<Entity, Key> where Entity : class
        // Entity sebagai class dan Key sebagai tipe data
    {
        public Entity Login(Entity Entity);
        public Entity Register(Entity Entity);

        public int ChangePassword(Entity Entiry);
        public int ForgotPassword(Entity Entiry);
    }
}
