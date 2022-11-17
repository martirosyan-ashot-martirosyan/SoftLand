using SoftLand.API.Handler.Interface;
using SoftLand.API.Mapper.Interface;
using SoftLand.API.Validator.Interface;
using SoftLand.Application.Model.Dto;
using SoftLand.Application.Service.Interface;

namespace SoftLand.API.Handler
{
    public class ShirtRequestHandler : IShirtRequestHandler
    {
        private readonly IShirtRequestValidator _requestValidator;
        private readonly IShirtGetRequestMapper _getRequestMapper;
        private readonly IShirtAddRequestMapper _addRequestMapper;
        private readonly IShirtResponseMapper _responseMapper;
        private readonly IShirtService _shirtService;


        public ShirtRequestHandler
        (
            IShirtRequestValidator requestValidator,
            IShirtGetRequestMapper getRequestMapper,
            IShirtAddRequestMapper addRequestMapper,
            IShirtResponseMapper responseMapper,
            IShirtService shirtService
        )
        {
            _requestValidator = requestValidator;
            _getRequestMapper = getRequestMapper;
            _addRequestMapper = addRequestMapper;
            _responseMapper = responseMapper;
            _shirtService = shirtService;
        }

        public async Task<ShirtDataResponse> AddAsync(ShirtDataRequest request)
        {

            _requestValidator.Validate(request);

            var dto = _addRequestMapper.Map(request);
            var result = await _shirtService.AddAsync(dto);

            return _responseMapper.Map(result);
        }

        public async Task<ShirtDataResponse> GetAsync(ShirtDataRequest request)
        {

            _requestValidator.Validate(request);

            var dto = _getRequestMapper.Map(request);
            var result = await _shirtService.GetAsync(dto);

            return _responseMapper.Map(result);
        }

        public async Task<List<ShirtDataResponse>> GetManyAsync(int count, ShirtDataRequest request)
        {

            _requestValidator.Validate(count, request);

            var dto = _getRequestMapper.Map(request);
            var result = await _shirtService.GetManyAsync(count, dto);

            return _responseMapper.Map(result);
        }

        public async Task<int> GetShirtCountAsync(ShirtDataRequest request)
        {

            _requestValidator.Validate(request);

            var dto = _getRequestMapper.Map(request);
            var result = await _shirtService.GetShirtCountAsync(dto);

            return result;
        }

        public async Task<List<ShirtDataResponse>> GetAllAsync()
        {

            var result = await _shirtService.GetAllAsync();

            return _responseMapper.Map(result);
        }
    }
}
