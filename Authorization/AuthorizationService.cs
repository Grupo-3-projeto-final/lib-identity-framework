using IdentityGama.Interface.Authorization;
using IdentityGamaFramework.Utils;
using System.Net.Http;

namespace IdentityGama.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly HttpClient _httpClient;

        public AuthorizationService()
        {
            _httpClient = new HttpClient();
        }

        public bool IsAuthorized(string token, string role)
        {
            string validationUrl = $"{Configuration.ValueAppSettings("URLIdentityServer")}/valid-role-token";
            var request = new HttpRequestMessage(HttpMethod.Head, validationUrl);
            request.Headers.Add("Authorization", $"Bearer {token}");
            request.Headers.Add("Role", role);

            try
            {
                var task = _httpClient.SendAsync(request);
                task.Wait(); // Aguarda o término da chamada assíncrona
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
