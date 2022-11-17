using SoftLand.API.Mapper.Interface;
using SoftLand.Application.Model;
using SoftLand.Application.Model.Dto;
using SoftLand.Domain.Entity.Dto;

namespace SoftLand.API.Mapper
{
    public class ShirtGetRequestMapper : IShirtGetRequestMapper
    {
        public ShirtDataModel Map(ShirtDataRequest dto)
        {

            var data = new DbShirtDataDTO();
            data.Size = dto.Size;
            data.Color = dto.Color?.ToUpper();

            return new ShirtDataModel
            {
                ShirtDataDTO = data
            };
        }
    }
}
