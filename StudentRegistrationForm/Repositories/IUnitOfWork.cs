namespace StudentRegistrationForm.Repositories
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        Task<int> CommitAsync();
    }
}
