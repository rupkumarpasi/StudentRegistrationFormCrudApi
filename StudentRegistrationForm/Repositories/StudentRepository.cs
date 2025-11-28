using Microsoft.EntityFrameworkCore;
using StudentRegistrationForm.Models;
using System;

namespace StudentRegistrationForm.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentRegistrationFormContext context) : base(context) { }

        public async Task<Student?> GetStudentWithDetails(Guid id)
        {
            return await _dbSet
                // Include related tables if needed
                //.Include(s => s.Citizenship)
                //.Include(s => s.ContactInfo)
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }
    }

}
