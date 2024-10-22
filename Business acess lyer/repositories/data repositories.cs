
using Microsoft.EntityFrameworkCore;
namespace Business_acess_lyer.repositories
{
    public class data_repositories : GenericRepositories<department>, Idata_repositories
    {

        public data_repositories(datacontextcs dbcontext) : base(dbcontext)
        {

        }
    }
}
