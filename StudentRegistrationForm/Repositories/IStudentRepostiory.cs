using StudentRegistrationForm.Models;

namespace StudentRegistrationForm.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student?> GetStudentWithDetails(Guid id);
    }
}
