using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using System.Reflection.Metadata.Ecma335;

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

        public async Task<Student?> GetStudentAsync(Guid studentId)
        {
            return await _context.Student
                .Include(nameof(Gender))
                .Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == studentId);
        }

        public Task<bool> Exists(Guid studentId)
        {
            return _context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student?> UpdateStudent(Guid studentId, Student request)
        {
            var existsStudent = await GetStudentAsync(studentId);
            if (existsStudent != null)
            {
                existsStudent.FirstName = request.FirstName;
                existsStudent.LastName = request.LastName;
                existsStudent.DateOfBirth = request.DateOfBirth;
                existsStudent.Email = request.Email;
                existsStudent.Mobile = request.Mobile;
                existsStudent.GenderId = request.GenderId;
                existsStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existsStudent.Address.PostalAddress = request.Address.PostalAddress;

                await _context.SaveChangesAsync();
                return existsStudent;
            }
            return null;
        }

        public async Task<Student?> DeleteStudent(Guid studentId)
        {
            var student=await GetStudentAsync(studentId);
            if (student != null) 
            {
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student?> AddStudemt(Student rwquest)
        {
            var addStudent= await _context.Student.AddAsync(rwquest);
            await _context.SaveChangesAsync();
            return addStudent.Entity;
        }
    }
}
