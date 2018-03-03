namespace DAL.Interfaces.DTO
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
