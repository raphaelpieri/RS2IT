using GameServices.Infra.Contexts;

namespace GameServices.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameServiceContext _context;

        public UnitOfWork(GameServiceContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            
        }
    }
}