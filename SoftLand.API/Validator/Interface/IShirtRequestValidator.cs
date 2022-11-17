using SoftLand.Application.Model.Dto;

namespace SoftLand.API.Validator.Interface
{
    public interface IShirtRequestValidator
    {

        void Validate(ShirtDataRequest request);

        void Validate(int count, ShirtDataRequest request);
    }
}
