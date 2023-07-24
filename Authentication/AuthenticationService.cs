using IdentityGamaFramework.Authentication.Interface;
using IdentityGamaFramework.Utils;
using System.Net.Http;

namespace IdentityGama.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService()
        {
            _httpClient = new HttpClient();
        }

        public bool IsAuthenticated(string token)
        {
            var validationUrl = $"{Configuration.ValueAppSettings("URLIdentityServer")}/valid-token";
            var request = new HttpRequestMessage(HttpMethod.Head, validationUrl);
            request.Headers.Add("Authorization", $"Bearer {token}");

            try
            {
                var task = _httpClient.SendAsync(request);
                task.Wait();
                var response = task.Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}
