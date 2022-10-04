using Android.OS;
using MauiAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppClient.Services
{
    internal class RestServices : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializer;

        public RestServices()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://" : "https://localhost";
            _url = $"{_baseAddress}/api";

            _jsonSerializer = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> users = new List<User>();

            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                //No internet access
                return users;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/users");

                if(response.IsSuccessStatusCode)
                {

                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                
            }

            return users;
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
