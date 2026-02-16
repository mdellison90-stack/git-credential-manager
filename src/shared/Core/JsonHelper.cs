using System.Text.Json;
using System.Text.Json.Serialization;

namespace GitCredentialManager
{
    /// <summary>
    /// Helper class providing common JSON serialization options and utilities.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Gets JSON serializer options configured for case-insensitive property names.
        /// </summary>
        public static JsonSerializerOptions CaseInsensitiveOptions { get; } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Gets JSON serializer options configured for case-insensitive property names
        /// and ignoring null values when writing.
        /// </summary>
        public static JsonSerializerOptions CaseInsensitiveIgnoreNullOptions { get; } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
    }
}
