using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace LambaApp.DataAccess
{
    public class GenericRepository<IEntity> : IGenericRepository<IEntity> where IEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<IEntity> _dbSet;

        public GenericRepository(LambaAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<IEntity>();

        }
        public async Task AddAsync(IEntity entity)
        {
            await _dbSet.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<IEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEntity> GetByIdAsync(int id)
        {
            var entity =  await _dbSet.FindAsync(id);
            return entity;
        }

        public void Remove(IEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEntity Update(IEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;

        }
    }

   

    
}
