using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SoftLand.Application.Model.Dto
{
    /// <summary>
    /// Shirt data request object
    /// </summary>
    public class ShirtDataRequest
    {
        /// <summary>
        /// Shirt size
        /// </summary>
        /// <example>44</example>
        [JsonProperty("size")]
        public short Size { get; set; }

        /// <summary>
        /// Shirt color
        /// </summary>
        /// <example>blue</example>
        [JsonProperty("color")]
        public string? Color { get; set; }
    }
}
