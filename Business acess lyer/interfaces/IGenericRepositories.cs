

namespace Business_acess_lyer.interfaces
{
    public interface IGenericRepositories<TEntity>
    {
        Task createasync(TEntity entity);
        void Delete(TEntity entity);
        Task< TEntity?> Getasync(int id);
        Task <IEnumerable<TEntity>> Getallasync();
        void update (TEntity entity);
    }
}
