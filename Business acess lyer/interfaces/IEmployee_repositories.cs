


namespace Business_acess_lyer.interfaces
{
    public interface IEmployee_repositories :IGenericRepositories<employee>
    {
       Task< IEnumerable<employee>> Getallasync(string name);
        Task <IEnumerable<employee>> getallwithdepartmentasync();
    }
}
