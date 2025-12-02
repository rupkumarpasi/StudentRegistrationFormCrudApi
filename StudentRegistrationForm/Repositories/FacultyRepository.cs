using Microsoft.EntityFrameworkCore;
using StudentRegistrationForm.Models;
using StudentRegistrationForm.Repositories;
using System;

public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
{
    public FacultyRepository(StudentRegistrationFormContext context) : base(context) { }

    public async Task<bool> ExistsAsync(Guid facultyId)
    {
        return await _context.Faculties.AnyAsync(f => f.FacultyId == facultyId);
    }
}