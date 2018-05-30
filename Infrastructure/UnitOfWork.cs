using System.Data.Entity;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public DatabaseContext Context { get; }

        public UnitOfWork(DatabaseContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
