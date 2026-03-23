// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GitCredentialManager;
using GitCredentialManager.Authentication.OAuth;

namespace Atlassian.Bitbucket.DataCenter
{
    public class BitbucketOAuth2Client : Bitbucket.BitbucketOAuth2Client
    {
        public BitbucketOAuth2Client(HttpClient httpClient, ISettings settings, ITrace2 trace2)
            : base(httpClient, GetEndpoints(settings),
                GetClientId(settings), GetRedirectUri(settings), GetClientSecret(settings), trace2)
        {
        }

        public override IEnumerable<string> Scopes => new string[] {
            DataCenterConstants.OAuthScopes.PublicRepos,
            DataCenterConstants.OAuthScopes.RepoRead,
            DataCenterConstants.OAuthScopes.RepoWrite
        };

        private static string GetClientId(ISettings settings)
        {
            return settings.GetRequiredOAuthConfigValue(
                DataCenterConstants.EnvironmentVariables.OAuthClientId,
                Constants.GitConfiguration.Credential.SectionName,
                DataCenterConstants.GitConfiguration.Credential.OAuthClientId,
                "Bitbucket DC OAuth Client ID must be defined");
        }

        private static Uri GetRedirectUri(ISettings settings)
        {
            return settings.GetOAuthConfigUri(
                DataCenterConstants.EnvironmentVariables.OAuthRedirectUri,
                Constants.GitConfiguration.Credential.SectionName,
                DataCenterConstants.GitConfiguration.Credential.OAuthRedirectUri,
                DataCenterConstants.OAuth2RedirectUri);
        }

        private static string GetClientSecret(ISettings settings)
        {
            return settings.GetRequiredOAuthConfigValue(
                DataCenterConstants.EnvironmentVariables.OAuthClientSecret,
                Constants.GitConfiguration.Credential.SectionName,
                DataCenterConstants.GitConfiguration.Credential.OAuthClientSecret,
                "Bitbucket DC OAuth Client Secret must be defined");
        }

        private static OAuth2ServerEndpoints GetEndpoints(ISettings settings)
        {
            var remoteUri = settings.RemoteUri;
            if (remoteUri == null)
            {
                throw new ArgumentException("RemoteUri must be defined to generate Bitbucket DC OAuth2 endpoint Urls");
            }

            return new OAuth2ServerEndpoints(
                new Uri(BitbucketHelper.GetBaseUri(remoteUri) + "/rest/oauth2/latest/authorize"),
                new Uri(BitbucketHelper.GetBaseUri(remoteUri) + "/rest/oauth2/latest/token")
                );
        }
    }
}
