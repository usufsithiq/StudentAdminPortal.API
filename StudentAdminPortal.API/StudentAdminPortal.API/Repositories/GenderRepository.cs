using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly StudentAdminContext _context;
        public GenderRepository(StudentAdminContext context)
        {
            _context = context;
        }
        public async Task<List<Gender>> GetGendersAsync()
        {
            return await _context.Gender.ToListAsync();
        }
    }
}
