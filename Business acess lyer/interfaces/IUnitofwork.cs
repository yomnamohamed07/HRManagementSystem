using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_acess_lyer.interfaces
{
    public interface IUnitofwork
    {
        public IEmployee_repositories employees { get; }
        public Idata_repositories data { get;  }
        public  Task<int> SaveChangesasync();
    }
}
