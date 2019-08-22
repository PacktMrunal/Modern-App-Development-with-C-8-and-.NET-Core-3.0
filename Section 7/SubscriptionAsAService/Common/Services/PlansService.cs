using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Common.Models;

namespace Common.Services
{
    public class PlansService : IPlansService
    {
        private string _endpoint = "http://10.0.2.2:3495/api/plans";
        private static HttpClient _httpClient = new HttpClient();
        private IAuthService _authService;

        public PlansService(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IEnumerable<Plan>> All()
        {
            var response = await _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint));
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Plan>>(body);
        }

        public async Task<Plan> Create(Plan plan)
        {
            var req = GetRequestTemplate(HttpMethod.Post, _endpoint);
            req.Content = new StringContent(JsonConvert.SerializeObject(plan));
            var response = await _httpClient.SendAsync(req);
            var body = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Plan>(body);
        }

        public async Task DeleteOne(int id)
        {
            var req = GetRequestTemplate(HttpMethod.Delete, _endpoint);
            await _httpClient.SendAsync(req);
        }

        private HttpRequestMessage GetRequestTemplate(HttpMethod method, string endpoint)
        {
            string accessToken = _authService.GetAccessToken();
            if (accessToken == null)
            {
                throw new Exception("You are not authorized to view this content");
            }
            HttpRequestMessage req = new HttpRequestMessage();
            req.Method = method;
            req.RequestUri = new Uri(endpoint);
            req.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            return req;
        }
    }
}
