using System;
using System.Runtime.Remoting.Contexts;
using EasyComTec.Infrastructure.Interfaces;

namespace EasyComTec.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public Context Context { get; }

        public UnitOfWork(Context context)
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
