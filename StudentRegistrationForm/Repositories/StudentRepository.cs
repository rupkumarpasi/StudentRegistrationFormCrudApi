using Microsoft.EntityFrameworkCore;
using StudentRegistrationForm.Models;
using System;

namespace StudentRegistrationForm.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentRegistrationFormContext context) : base(context) { }

        public async Task<Student?> GetStudentWithDetailsAsync(Guid id)
        {
            return await _context.Students
        .Include(s => s.PersonalDetail)
        .Include(s => s.ContactInfo)
        .Include(s => s.Citizenship)
        .Include(s => s.EthnicityInfo)
        .Include(s => s.Financial)
        .Include(s => s.Transportation)
        .Include(s => s.DocumentInfo)
        .Include(s => s.Addresses)
        .Include(s => s.Guardians)
        .Include(s => s.AcademicHistories)
        .Include(s => s.EmergencyContacts)
        .Include(s => s.Enrollments)
        .Include(s => s.Achievements)
        .Include(s => s.Extracurriculars)
        .Include(s => s.Scholarships)
        .FirstOrDefaultAsync(s => s.StudentId == id);
                
        }
    }

}
