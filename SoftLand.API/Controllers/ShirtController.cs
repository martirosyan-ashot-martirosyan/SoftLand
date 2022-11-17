using Microsoft.AspNetCore.Mvc;
using SoftLand.API.Handler.Interface;
using SoftLand.Application.Model.Dto;

namespace SoftLand.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtController : ControllerBase
    {

        private readonly IShirtRequestHandler _shirtRequestHandler;

        public ShirtController(IShirtRequestHandler shirtRequestHandler)
        {
            _shirtRequestHandler = shirtRequestHandler;
        }

        [HttpGet("GetShirt")]
        public async Task<ActionResult<ShirtDataResponse>> Get([FromQuery] ShirtDataRequest request)
        {
            var result = await _shirtRequestHandler.GetAsync(request);

            return result;
        }

        [HttpGet("GetManyShirts")]
        public async Task<ActionResult<IEnumerable<ShirtDataResponse>>> GetMany([FromQuery] int count, 
                                                                                [FromQuery] ShirtDataRequest request)
        {
            var result = await _shirtRequestHandler.GetManyAsync(count, request);

            return result;
        }

        [HttpGet("GetShirtsCount")]
        public async Task<ActionResult<int>> GetCount([FromQuery] ShirtDataRequest request)
        {
            var result = await _shirtRequestHandler.GetShirtCountAsync(request);

            return result;
        }

        [HttpGet("GetAllShirts")]
        public async Task<ActionResult<IEnumerable<ShirtDataResponse>>> GetAll()
        {
            var result = await _shirtRequestHandler.GetAllAsync();

            return result;
        }

        [HttpPost("AddShirt")]
        public async Task<ActionResult<ShirtDataResponse>> Add([FromQuery] ShirtDataRequest request)
        {
            var result = await _shirtRequestHandler.AddAsync(request);

            return result;
        }
    }
}
