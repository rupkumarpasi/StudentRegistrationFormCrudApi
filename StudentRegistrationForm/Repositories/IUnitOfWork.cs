namespace StudentRegistrationForm.Repositories
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        IFacultyRepository Faculties { get; }
        Task<int> CommitAsync();
    }
}
