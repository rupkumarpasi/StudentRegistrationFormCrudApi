
using StudentRegistrationForm.Models;
using StudentRegistrationForm.Models.DTOs;

namespace StudentRegistrationForm.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student> CreateFromDtoAsync(StudentCreateDto student);
        Task<bool> UpdateAsync(Guid id, Student student);
        Task<bool> DeleteAsync(Guid id);
    }
}
