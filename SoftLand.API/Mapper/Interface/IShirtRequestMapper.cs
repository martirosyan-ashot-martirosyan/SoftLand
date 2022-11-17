using SoftLand.Application.Model;
using SoftLand.Application.Model.Dto;

namespace SoftLand.API.Mapper.Interface
{
    public interface IShirtRequestMapper
    {

        ShirtDataModel Map(ShirtDataRequest dto);
    }
}
