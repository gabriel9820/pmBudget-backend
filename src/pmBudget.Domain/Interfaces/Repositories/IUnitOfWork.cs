namespace pmBudget.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
