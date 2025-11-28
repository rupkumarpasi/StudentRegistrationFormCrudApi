using StudentRegistrationForm.Models;
using System;

namespace StudentRegistrationForm.Repositories
{
    // UnitOfWork/UnitOfWork.cs

    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudentRegistrationFormContext _context;

        public IStudentRepository Students { get; }

        public UnitOfWork(StudentRegistrationFormContext context)
        {
            _context = context;
            Students = new StudentRepository(context);
        }

        public async Task<int> CommitAsync() =>
            await _context.SaveChangesAsync();
    }

}
