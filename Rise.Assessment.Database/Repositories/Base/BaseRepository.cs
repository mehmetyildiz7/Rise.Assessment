using log4net;
using Microsoft.EntityFrameworkCore;
using Rise.Assessment.Common.Filters;
using Rise.Assessment.Database.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rise.Assessment.Database.Repositories.Base
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseRepository<Entity>));

        protected DbSet<Entity> Entities;
        private bool disposedValue;
        private RiseDbContext _context;
        public BaseRepository(RiseDbContext context)
        {
            _context = context;
        }

        public async Task<Entity> Get(object id)
        {
            var result = await Entities.FindAsync(id);
            log.Info($"Entity with ID = {id} returned from table = {typeof(Entity).Name}");

            return result;
        }

        public async Task<IEnumerable<Entity>> GetAll()
        {
            var result = Entities.Where(x => x.IsDeleted == false);
            log.Info($"All entities returned from table = {typeof(Entity).Name}");

            return await result.ToListAsync();
        }

        public async Task<Entity> Add(Entity obj)
        {
            obj.Id = Guid.NewGuid();
            obj.CreateDate = DateTime.Now;
            obj.ModifiedDate = DateTime.Now;
            obj.IsDeleted = false;

            var result = await Entities.AddAsync(obj);
            await _context.SaveChangesAsync();
            log.Info($"Entity with ID = {obj.Id} added to table = {typeof(Entity).Name}");

            return result.Entity;
        }

        public async Task<Entity> DeleteAsync(object id)
        {
            var result = await Entities.FindAsync(id);
            result.ModifiedDate = DateTime.Now;
            result.IsDeleted = true;
            await _context.SaveChangesAsync();
            log.Info($"Entity with ID = {id} deleted from table = {typeof(Entity).Name}");

            return result;
        }

        public async Task<Entity> UpdateAsync(Entity obj)
        {
            var result = Entities.Update(obj);
            result.Entity.ModifiedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            log.Info($"Entity with ID = {obj.Id} updated in table = {typeof(Entity).Name}");

            return result.Entity;
        }

        #region Dispose methods
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BaseRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
        #endregion

    }
}