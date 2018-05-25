using System;
using System.Data.Entity;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        void Commit();
    }
}
