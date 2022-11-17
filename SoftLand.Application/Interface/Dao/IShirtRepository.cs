using SoftLand.Domain.Entity;
using SoftLand.Domain.Entity.Dto;

namespace SoftLand.Application.Interface.Dao
{
    public interface IShirtRepository
    {

        Task<DbShirtDataEntity> AddAsync(DbShirtDataEntity entity);

        Task<DbShirtDataDTO?> GetAsync(DbShirtDataDTO shirtData);

        Task<List<DbShirtDataDTO>> GetManyAsync(int count, DbShirtDataDTO shirtData);

        Task<int> GetShirtsCountAsync(DbShirtDataDTO shirtData);

        Task<List<DbShirtDataDTO>> GetAllAsync();
    }
}
