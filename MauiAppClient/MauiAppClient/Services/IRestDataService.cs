using MauiAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppClient.Services
{
    public interface IRestDataService
    {
        Task<List<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);    
        Task DeleteUserAsync(int id);
    }
}
