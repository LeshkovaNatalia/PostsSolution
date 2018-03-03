namespace DAL.Interfaces.Repository
{
    using System.Collections.Generic;
    using DAL.Interfaces.DTO;
    using System.Threading.Tasks;
    
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int key);
        TEntity GetById(int key);
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int key);
        void Update(TEntity entity);
    }
}
