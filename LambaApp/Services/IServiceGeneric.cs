using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LambaApp.Services
{
    public interface IServiceGeneric<IEntity> where IEntity : class
    {
        Task<Response<IEntity>> GetByIdAsync(int id);
        Task<Response<IEnumerable<IEntity>>> GetAllAsync();
 
        Task<Response<IEntity>> AddAsync(IEntity entity);
        Task<Response<NoDataDto>> Remove(int entity);
       Response<IEntity> Update(IEntity entity);
    }
}
