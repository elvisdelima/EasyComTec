using System;
using System.Runtime.Remoting.Contexts;

namespace EasyComTec.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Context Context { get; }
        void Commit();
    }
}
