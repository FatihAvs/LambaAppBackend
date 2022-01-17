using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambaApp.DataAccess
{
    public interface IGenericRepository<IEntity> where IEntity:class
    {
        IEntity Update(IEntity entity);
        Task AddAsync(IEntity entity);
        void Remove(IEntity entity);
        Task<IEntity> GetByIdAsync(int id);
        Task<IEnumerable<IEntity>> GetAllAsync();

    }
}
