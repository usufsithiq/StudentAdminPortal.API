using Microsoft.Identity.Client.Extensibility;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public interface IGenderRepository
    {   
        public Task<List<Gender>> GetGendersAsync();
    }
}
