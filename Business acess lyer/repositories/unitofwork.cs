using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_acess_lyer.interfaces;
namespace Business_acess_lyer.repositories
{
    public class Unitofwork : IUnitofwork
    {
        private readonly Lazy<IEmployee_repositories> _emprepo;
        private readonly Lazy<Idata_repositories >_datatrepo;
        private readonly datacontextcs _context;
        public Unitofwork(datacontextcs context)
        {
            _emprepo = new Lazy<IEmployee_repositories>(() => new Employee_repositories(context));
            _datatrepo = new Lazy<Idata_repositories>(()=>new data_repositories(context));
            _context = context;
        }
        public IEmployee_repositories employees => _emprepo.Value;
        public Idata_repositories data => _datatrepo.Value;
        public async  Task<int> SaveChangesasync() =>  await _context.SaveChangesAsync();
    }
}
