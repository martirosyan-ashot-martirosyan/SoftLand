using SoftLand.Application.Model;

namespace SoftLand.Application.Service.Interface
{
    public interface IShirtService
    {

        Task<ShirtDataModel> GetAsync(ShirtDataModel model);
        
        Task<ShirtDataModel> AddAsync(ShirtDataModel model);

        Task<List<ShirtDataModel>> GetManyAsync(int count, ShirtDataModel model);

        Task<int> GetShirtCountAsync(ShirtDataModel model);

        Task<List<ShirtDataModel>> GetAllAsync();
    }
}
