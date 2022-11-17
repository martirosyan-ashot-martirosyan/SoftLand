using SoftLand.API.Mapper.Interface;
using SoftLand.Application.Model;
using SoftLand.Application.Model.Dto;

namespace SoftLand.API.Mapper
{
    public class ShirtResponseMapper : IShirtResponseMapper
    {
        public ShirtDataResponse Map(ShirtDataModel model)
        {
            var response = new ShirtDataResponse();

            if (model is null || model.ShirtDataDTO is null)
                return response;

            var size = model?.ShirtDataDTO?.Size;
            var color = model?.ShirtDataDTO?.Color?.ToUpper();

            response.Color = color;
            response.Size = size;

            return response;
        }

        public List<ShirtDataResponse> Map(List<ShirtDataModel> models)
        {

            var responseList = new List<ShirtDataResponse>();

            foreach (var model in models)
            {
                responseList.Add(Map(model));
            }

            return responseList;
        }
    }
}
