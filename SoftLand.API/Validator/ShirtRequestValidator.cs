using SoftLand.API.Validator.Interface;
using SoftLand.Application.Model.Dto;

namespace SoftLand.API.Validator
{
    public class ShirtRequestValidator : IShirtRequestValidator
    {
        public void Validate(ShirtDataRequest request)
        {

            if (request is null)
                throw new BadHttpRequestException("Request model is null");

            if (request.Size <= 0)
                throw new BadHttpRequestException("Incorrect data for filed size");

            var color = request.Color?.ToUpper();

            if (String.IsNullOrWhiteSpace(color))
                throw new BadHttpRequestException("The field color can't be null");

            Validate(color);
        }

        public void Validate(int count, ShirtDataRequest request)
        {
            if (count <= 0)
                throw new BadHttpRequestException("Incorrect data for filed count");

            Validate(request);
        }

        private void Validate(string color)
        {

            switch (color)
            {
                case "RED": break;
                case "BLUE": break;
                case "YELLOW": break;
                case "ORANGE": break;
                case "BLACK": break;
                case "WHITE": break;
                case "GREEN": break;
                default: throw new BadHttpRequestException("Invalid Color");
            }
        }
    }
}
