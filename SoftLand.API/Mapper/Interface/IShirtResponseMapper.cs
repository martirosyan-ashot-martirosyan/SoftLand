using SoftLand.Application.Model;
using SoftLand.Application.Model.Dto;

namespace SoftLand.API.Mapper.Interface
{
    public interface IShirtResponseMapper
    {

        ShirtDataResponse Map(ShirtDataModel model);

        List<ShirtDataResponse> Map(List<ShirtDataModel> models);
    }
}
