using SoftLand.Domain.Entity;
using SoftLand.Domain.Entity.Dto;

namespace SoftLand.Application.Model
{
    public class ShirtDataModel
    {
        public DbShirtDataEntity? ShirtDataEntity { get; set; }

        public DbShirtDataDTO? ShirtDataDTO { get; set; }
    }
}
