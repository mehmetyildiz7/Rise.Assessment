using AutoMapper;
using Rise.Assessment.Database.Entities.Base;
using Rise.Assessment.Database.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rise.Assessment.Business.Services.Base
{
    public abstract class BaseService<Entity> : IBaseService<Entity> where Entity : BaseEntity
    {
        protected readonly IBaseRepository<Entity> Repository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<Entity> repository, IMapper mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public async Task<Entity> CreateAsync(object entityModel)
        {
            var entity = _mapper.Map<Entity>(entityModel);
            var result = await Repository.Add(entity);
            return result;
        }

        public async Task<Entity> DeleteAsync(object id)
        {
            var result = await Repository.DeleteAsync(id);
            return result;
        }

        public async Task<Entity> FindAsync(object id)
        {
            var entity = await Repository.Get(id);
            return entity;
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            var list = await Repository.GetAll();
            return list;
        }

        public async Task<Entity> UpdateAsync(object entityModel)
        {
            var entity = _mapper.Map<Entity>(entityModel);
            var result = await Repository.UpdateAsync(entity);
            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseService()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
