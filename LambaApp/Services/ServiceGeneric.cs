using LambaApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LambaApp.Services
{
    public class ServiceGeneric<IEntity> : IServiceGeneric<IEntity> where IEntity : class
    {
     
        private readonly IGenericRepository<IEntity> _genericRepository;
        public ServiceGeneric( IGenericRepository<IEntity> genericRepository)
        {
            
            _genericRepository = genericRepository;
        }

        public async Task<Response<IEntity>> AddAsync(IEntity entity)
        {
            await _genericRepository.AddAsync(entity);
            return Response<IEntity>.Success(entity, 200);
        }

        public async Task<Response<IEnumerable<IEntity>>> GetAllAsync()
        {
            var newEntites =  await _genericRepository.GetAllAsync();
            return Response<IEnumerable<IEntity>>.Success(newEntites, 200);
        }

        public async Task<Response<IEntity>> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            return Response<IEntity>.Success(entity, 200);
        }

        public async Task<Response<NoDataDto>> Remove(int entity)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(entity);
            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }
            _genericRepository.Remove(isExistEntity);
           
            return Response<NoDataDto>.Success(200);
        }

        public  Response<IEntity> Update(IEntity entity)
        {
           

            var ResponseEntity =  _genericRepository.Update(entity);
            return Response<IEntity>.Success(ResponseEntity,200);



        }

       
    }
}
