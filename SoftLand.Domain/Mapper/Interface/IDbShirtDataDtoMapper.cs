using SoftLand.Domain.Entity;
using SoftLand.Domain.Entity.Dto;

namespace SoftLand.Domain.Mapper.Interface
{
    public interface IDbShirtDataDtoMapper
    {

        DbShirtDataDTO Map(DbShirtDataEntity entity);

        List<DbShirtDataDTO> Map(List<DbShirtDataEntity> entities);
    }
}
