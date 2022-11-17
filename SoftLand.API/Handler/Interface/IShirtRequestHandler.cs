using SoftLand.Application.Model.Dto;

namespace SoftLand.API.Handler.Interface
{
    public interface IShirtRequestHandler
    {

        Task<ShirtDataResponse> GetAsync(ShirtDataRequest request);

        Task<ShirtDataResponse> AddAsync(ShirtDataRequest request);

        Task<List<ShirtDataResponse>> GetManyAsync(int count, ShirtDataRequest request);

        Task<int> GetShirtCountAsync(ShirtDataRequest request);

        Task<List<ShirtDataResponse>> GetAllAsync();
    }
}
