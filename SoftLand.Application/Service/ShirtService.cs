using SoftLand.Application.Interface.Dao;
using SoftLand.Application.Model;
using SoftLand.Application.Service.Interface;
using SoftLand.Domain.Entity;
using SoftLand.Domain.Entity.Dto;
using SoftLand.Domain.Mapper.Interface;

namespace SoftLand.Application.Service
{
    public class ShirtService : IShirtService
    {
        private readonly IShirtRepository _shirtRepository;
        private readonly IDbShirtDataDtoMapper _shirtDataDtoMapper;

        public ShirtService
        (
            IShirtRepository shirtRepository,
            IDbShirtDataDtoMapper shirtDataDtoMapper
        )
        {
            _shirtRepository = shirtRepository;
            _shirtDataDtoMapper = shirtDataDtoMapper;
        }

        public async Task<ShirtDataModel> AddAsync(ShirtDataModel model)
        {
            var entity = model.ShirtDataEntity;
            var result = await _shirtRepository.AddAsync(entity);

            return GetShirtDataModel(result);
        }

        public async Task<ShirtDataModel> GetAsync(ShirtDataModel model)
        {

            var data = model.ShirtDataDTO;
            var result = await _shirtRepository.GetAsync(data);

            if (result is null)
                throw new Exception("Shirt does not exist");

            return GetShirtDataModel(result);
        }

        public async Task<List<ShirtDataModel>> GetManyAsync(int count, ShirtDataModel model)
        {
            var data = model.ShirtDataDTO;
            var currentCount = await _shirtRepository.GetShirtsCountAsync(data);

            if (currentCount < count)
                throw new Exception($"There are only {currentCount} items in stock");

            var resultList = await _shirtRepository.GetManyAsync(count, data);


            return GetShirtDataList(resultList);
        }

        public async Task<int> GetShirtCountAsync(ShirtDataModel model)
        {
            var data = model.ShirtDataDTO;
            var result = await _shirtRepository.GetShirtsCountAsync(data);

            return result;
        }

        public async Task<List<ShirtDataModel>> GetAllAsync()
        {
            var result = await _shirtRepository.GetAllAsync();

            if (result.Count == 0)
                throw new Exception("Shirts does not exist");

            return GetShirtDataList(result);
        }


        #region Processing

        private ShirtDataModel GetShirtDataModel(DbShirtDataEntity entity)
        {
            var dataModel = _shirtDataDtoMapper.Map(entity);

            return GetShirtDataModel(dataModel);
        }

        private ShirtDataModel GetShirtDataModel(DbShirtDataDTO model)
        {
            return new ShirtDataModel
            {
                ShirtDataDTO = model,
            };
        }

        private List<ShirtDataModel> GetShirtDataList(List<DbShirtDataDTO> models)
        {
            var result = new List<ShirtDataModel>();

            for (var i = 0; i < models.Count; i++)
            {
                var data = new ShirtDataModel();

                data.ShirtDataDTO = models[i];
                result.Add(data);
            }

            return result;
        }
        #endregion
    }
}
