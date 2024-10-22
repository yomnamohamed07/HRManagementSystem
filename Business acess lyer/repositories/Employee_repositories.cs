



using Microsoft.EntityFrameworkCore;

namespace Business_acess_lyer.repositories
{
    public class Employee_repositories : GenericRepositories<employee>, IEmployee_repositories
    {
        public Employee_repositories(datacontextcs dbcontext) : base(dbcontext)
        {
            
        }

        public async Task<IEnumerable<employee>> Getallasync(string name)
        
         => await   _dbset.Where(e => e.name.ToLower().Contains(name.ToLower())).Include(e => e.department).ToListAsync ();
        
       public async Task< IEnumerable<employee>> getallwithdepartmentasync()
        
           => await _dbset.Include(e => e.department).ToListAsync();
        
    }
}