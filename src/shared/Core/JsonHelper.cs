using System.Text.Json;
using System.Text.Json.Serialization;

namespace GitCredentialManager
{
    /// <summary>
    /// Helper class providing common JSON serialization options and utilities.
    /// </summary>
    /// <remarks>
    /// The shared JsonSerializerOptions instances should not be modified after initialization
    /// to ensure thread safety across the application.
    /// </remarks>
    public static class JsonHelper
    {
        /// <summary>
        /// Gets JSON serializer options configured for case-insensitive property names.
        /// Do not modify this instance; create a new instance if different options are needed.
        /// </summary>
        public static JsonSerializerOptions CaseInsensitiveOptions { get; } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Gets JSON serializer options configured for case-insensitive property names
        /// and ignoring null values when writing.
        /// Do not modify this instance; create a new instance if different options are needed.
        /// </summary>
        public static JsonSerializerOptions CaseInsensitiveIgnoreNullOptions { get; } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }
}
