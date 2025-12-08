
using StudentRegistrationForm.Dto;
using StudentRegistrationForm.Models;


namespace StudentRegistrationForm.Services
{
    public interface IStudentService
    {
 
        Task<Student?> GetByIdAsync(Guid id);
        Task<Student> CreateFromDtoAsync(CreateStudentRequest student);

        Task<bool> UpdateStudentAsync(int id, CreateStudentRequest student);
     
    }
}
