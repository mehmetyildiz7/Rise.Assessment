using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Assessment.Database.Repositories.Base
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Get(object id);
        Task<TEntity> Add(TEntity obj);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> UpdateAsync(TEntity obj);
        Task<TEntity> DeleteAsync(TEntity obj);
    }
}
