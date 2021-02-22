using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Assessment.Business.Services.Base
{
    public interface IBaseService<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(object entityModel);
        Task<TEntity> FindAsync(object id);
        Task<TEntity> UpdateAsync(object entityModel);
        Task<TEntity> DeleteAsync(object id);
    }
}
