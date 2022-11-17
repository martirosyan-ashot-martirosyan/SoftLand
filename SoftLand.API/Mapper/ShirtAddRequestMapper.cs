using SoftLand.API.Mapper.Interface;
using SoftLand.Application.Model;
using SoftLand.Application.Model.Dto;
using SoftLand.Domain.Entity;

namespace SoftLand.API.Mapper
{
    public class ShirtAddRequestMapper : IShirtAddRequestMapper
    {

        public ShirtDataModel Map(ShirtDataRequest dto)
        {

            var data = new DbShirtDataEntity();
            data.Size = dto.Size;
            data.Color = dto.Color?.ToUpper();

            return new ShirtDataModel
            {
                ShirtDataEntity = data
            };
        }
    }
}
