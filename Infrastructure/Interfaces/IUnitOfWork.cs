using System;
using System.Data.Entity;
using Infrastructure.Data;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DatabaseContext Context { get; }
        void Commit();
    }
}
