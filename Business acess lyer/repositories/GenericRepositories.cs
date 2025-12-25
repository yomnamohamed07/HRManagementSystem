

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Business_acess_lyer.repositories
{
    public class GenericRepositories<TEntity> :IGenericRepositories<TEntity>  where TEntity : class
    {
        //ctor injection
        private  datacontextcs _datacontext;
       protected DbSet<TEntity> _dbset;
        public GenericRepositories(datacontextcs dbcontext)
        {
            _datacontext = dbcontext;
            _dbset = dbcontext.Set<TEntity>();
        }
        public async Task<TEntity?> Getasync(int id)

		   => await _dbset.FindAsync(id);
        
        
        public  async Task <IEnumerable<TEntity>> Getallasync()
       
             =>  await _dbset.ToListAsync();

        public async Task createasync(TEntity entity) => await _dbset.AddAsync(entity); 
            
        
        public void update(TEntity entity)
        {
            _dbset.Update(entity);
         
           
        }
        public void Delete(TEntity entity)
           => _dbset.Remove(entity);

     
    }
}
