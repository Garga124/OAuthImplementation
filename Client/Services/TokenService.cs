using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Client.Services
{
    public class TokenService : ITokenService
    {
        public readonly IOptions<IdentityServerSettings> identityServerSettings;
        public readonly DiscoveryDocumentResponse discoveryDocument;
        public readonly HttpClient httpClient;
        public async Task<TokenResponse> GetToken(string scope)
        {
            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = identityServerSettings.Value.ClientName,
                    ClientSecret = identityServerSettings.Value.ClientPassword,
                    Scope = scope
                });
                if (tokenResponse.IsError)
            {
                throw new Exception("Unable to get Token", tokenResponse.Exception);
            }
                return tokenResponse;
            
                }

        public TokenService(IOptions<IdentityServerSettings> identityServerSettings)
        {
            this.identityServerSettings = identityServerSettings;
            httpClient = new HttpClient();
            discoveryDocument = httpClient.GetDiscoveryDocumentAsync(this.identityServerSettings.Value.DiscoveryUrl).Result;
            if (discoveryDocument.IsError)
            {
                throw new Exception("Unable to get Discovery Document", discoveryDocument.Exception);
            }
        }
    }
}
