using System;

namespace GitCredentialManager.Authentication.OAuth
{
    /// <summary>
    /// Helper class for retrieving OAuth2 configuration settings from environment variables or Git configuration.
    /// </summary>
    public static class OAuth2SettingsHelper
    {
        /// <summary>
        /// Retrieves an OAuth configuration value from settings, with fallback to a default value.
        /// </summary>
        /// <param name="settings">The settings instance to query.</param>
        /// <param name="environmentVariable">The environment variable name.</param>
        /// <param name="configSection">The Git configuration section name.</param>
        /// <param name="configProperty">The Git configuration property name.</param>
        /// <param name="defaultValue">The default value to return if no setting is found.</param>
        /// <returns>The configured value if found, otherwise the default value.</returns>
        public static string GetOAuthConfigValue(
            this ISettings settings,
            string environmentVariable,
            string configSection,
            string configProperty,
            string defaultValue)
        {
            if (settings.TryGetSetting(environmentVariable, configSection, configProperty, out string value))
            {
                return value;
            }

            return defaultValue;
        }

        /// <summary>
        /// Retrieves a required OAuth configuration value from settings, throwing an exception if not found.
        /// </summary>
        /// <param name="settings">The settings instance to query.</param>
        /// <param name="environmentVariable">The environment variable name.</param>
        /// <param name="configSection">The Git configuration section name.</param>
        /// <param name="configProperty">The Git configuration property name.</param>
        /// <param name="errorMessage">The error message to include in the exception if the value is not found.</param>
        /// <returns>The configured value.</returns>
        /// <exception cref="ArgumentException">Thrown when the required value is not found.</exception>
        public static string GetRequiredOAuthConfigValue(
            this ISettings settings,
            string environmentVariable,
            string configSection,
            string configProperty,
            string errorMessage)
        {
            if (settings.TryGetSetting(environmentVariable, configSection, configProperty, out string value))
            {
                return value;
            }

            throw new ArgumentException(errorMessage);
        }

        /// <summary>
        /// Retrieves an OAuth configuration URI from settings, with fallback to a default value.
        /// </summary>
        /// <param name="settings">The settings instance to query.</param>
        /// <param name="environmentVariable">The environment variable name.</param>
        /// <param name="configSection">The Git configuration section name.</param>
        /// <param name="configProperty">The Git configuration property name.</param>
        /// <param name="defaultValue">The default URI to return if no setting is found.</param>
        /// <returns>The configured URI if found and valid, otherwise the default URI.</returns>
        public static Uri GetOAuthConfigUri(
            this ISettings settings,
            string environmentVariable,
            string configSection,
            string configProperty,
            Uri defaultValue)
        {
            if (settings.TryGetSetting(environmentVariable, configSection, configProperty, out string uriStr) &&
                Uri.TryCreate(uriStr, UriKind.Absolute, out Uri uri))
            {
                return uri;
            }

            return defaultValue;
        }
    }
}
