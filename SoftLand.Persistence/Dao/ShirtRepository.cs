using Microsoft.EntityFrameworkCore;
using SoftLand.Application.Interface.Dao;
using SoftLand.Domain.Entity;
using SoftLand.Domain.Entity.Dto;
using SoftLand.Domain.Mapper.Interface;
using SoftLand.Persistence.Context;

namespace SoftLand.Persistence.Dao
{
    public class ShirtRepository : IShirtRepository
    {
        private readonly ShirtDbContext _dbContext;
        private readonly IDbShirtDataDtoMapper _mapper;

        public ShirtRepository
        (
            ShirtDbContext dbContext,
            IDbShirtDataDtoMapper mapper
        )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DbShirtDataEntity> AddAsync(DbShirtDataEntity entity)
        {
            var result = _dbContext.DbShirtDatas.AddAsync(entity).Result;
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<DbShirtDataDTO?> GetAsync(DbShirtDataDTO shirtData)
        {
            var size = shirtData.Size;
            var color = shirtData.Color;

            var entity = 
                await _dbContext.DbShirtDatas.FirstOrDefaultAsync(s => s.Size == size && s.Color == color);

            if (entity is null)
                return null;

             _dbContext.DbShirtDatas.Remove(entity);
            await _dbContext.SaveChangesAsync();

            var result = new DbShirtDataDTO();

            result.Size = entity.Size;
            result.Color = entity.Color;

            return result;
        }

        public async Task<List<DbShirtDataDTO>> GetManyAsync(int count, DbShirtDataDTO shirtData)
        {

            var size = shirtData.Size;
            var color = shirtData.Color;

            var entities =  _dbContext.DbShirtDatas.Where(s => s.Size == size && s.Color == color);
            var entityList = entities.Take(count).ToList();

            var dataList = new List<DbShirtDataEntity>();
            dataList.AddRange(entityList);

            _dbContext.DbShirtDatas.RemoveRange(entityList);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map(dataList);
        }

        public async Task<int> GetShirtsCountAsync(DbShirtDataDTO shirtData)
        {
            var size = shirtData.Size;
            var color = shirtData.Color;

            var count = 
                await _dbContext.DbShirtDatas.Where(s => s.Size == size && s.Color == color).CountAsync();

            return count;
        }

        public async Task<List<DbShirtDataDTO>> GetAllAsync()
        {
            var result = await _dbContext.DbShirtDatas.ToListAsync();

            return _mapper.Map(result);
        }  
    }
}
