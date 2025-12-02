using StudentRegistrationForm.Models;
using StudentRegistrationForm.Repositories;

public interface IFacultyRepository : IGenericRepository<Faculty>
{
    Task<bool> ExistsAsync(Guid facultyId);
}