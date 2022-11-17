using Newtonsoft.Json;

namespace SoftLand.Application.Model.Dto
{
    // <summary>
    /// Shirt data response object
    /// </summary>
    public class ShirtDataResponse
    {
        /// <summary>
        /// Shirt size
        /// </summary>
        [JsonProperty("size")]
        public short? Size { get; set; }

        /// <summary>
        /// Shirt color
        /// </summary>
        [JsonProperty("color")]
        public string? Color { get; set; }
    }
}
