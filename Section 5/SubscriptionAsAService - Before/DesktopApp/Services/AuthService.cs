using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared.ViewModels;

namespace DesktopApp.Services
{
    public class AuthService : IAuthService
    {
        private string _signUpEndpoint = "http://localhost:6842/api/users/signup";
        private string _signInEndpoint = "http://localhost:6842/api/users/signin";
        private string _currentAccessToken = "";

        public event EventHandler<EventArgs> AccessTokenChanged;

        private static HttpClient _httpClient = new HttpClient();

        public async Task<string> SignIn(UserSignInVM user)
        {
            return await AuthAction(_signInEndpoint, user);
        }

        public async Task<string> SignUp(UserSignUpVM user)
        {
            return await AuthAction(_signUpEndpoint, user);
        }

        public string GetAccessToken()
        {
            return _currentAccessToken;
        }

        public async Task<string> AuthAction<T>(string endpoint, T content)
        {
            var body = JsonConvert.SerializeObject(content);
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, new StringContent(body, Encoding.UTF8, "application/json"));
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            else
            {
                string accessToken = await response.Content.ReadAsStringAsync();
                if (accessToken.Length == 0)
                {
                    _currentAccessToken = null;
                    return null;
                }
                else
                {
                    _currentAccessToken = accessToken;
                    AccessTokenChanged?.Invoke(this, new EventArgs());
                    return accessToken;
                }
            }
        }
               
    }
}
