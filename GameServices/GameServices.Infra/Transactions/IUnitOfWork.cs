namespace GameServices.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}