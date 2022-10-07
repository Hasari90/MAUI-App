using MauiAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;

namespace MauiAppClient.Services
{
    internal class RestServices : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializer;

        public RestServices(HttpClient httpClient)
        {
            //_httpClient = new HttpClient();
            _httpClient = httpClient;   

            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://" : "https://localhost";
            _url = $"{_baseAddress}/api";

            _jsonSerializer = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task AddUserAsync(User user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access");
                return;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize<User>(user, _jsonSerializer);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/users", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("OK");
                }
                else
                {
                    Debug.WriteLine("Error - non http 2xx");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return;
        }

        public async Task DeleteUserAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access");
                return;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/users/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("OK");
                }
                else
                {
                    Debug.WriteLine("Error - non http 2xx");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = new List<User>();

            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access"); 
                return users;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/users");

                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    users = JsonSerializer.Deserialize<List<User>>(content, _jsonSerializer);

                    Debug.WriteLine("OK");
                }
                else
                {
                    Debug.WriteLine("Error - non http 2xx");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return users;
        }

        public async Task UpdateUserAsync(User user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No internet access");
                return;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize<User>(user, _jsonSerializer);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/users/{user.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("OK");
                }
                else
                {
                    Debug.WriteLine("Error - non http 2xx");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return;
        }
    }
}
