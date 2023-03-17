﻿using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;

namespace StudentAdminPortal.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;

        public StudentRepository(StudentAdminContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}
