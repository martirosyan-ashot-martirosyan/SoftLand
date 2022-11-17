using SoftLand.Domain.Entity;
using SoftLand.Domain.Entity.Dto;
using SoftLand.Domain.Mapper.Interface;

namespace SoftLand.Domain.Mapper
{
    public class DbShirtDataDtoMapper : IDbShirtDataDtoMapper
    {
        public DbShirtDataDTO Map(DbShirtDataEntity entity)
        {

            var size = entity.Size;
            var color = entity.Color;

            return new DbShirtDataDTO
            {
                Size = size,
                Color = color
            };
        }

        public List<DbShirtDataDTO> Map(List<DbShirtDataEntity> entities)
        {
            var result = new List<DbShirtDataDTO>();

            for (var i = 0; i < entities.Count; i++)
            {
                var data = new DbShirtDataDTO();
                var size = entities[i].Size;
                var color = entities[i].Color;

                data.Size = size;
                data.Color = color;

                result.Add(data);
            }

            return result;
        }
    }
}
