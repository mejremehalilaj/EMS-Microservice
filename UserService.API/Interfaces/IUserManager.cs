using UserService.API.Models;

namespace UserService.API.Interfaces
{
    public interface IUserManager
    {
        Task<List<UserModel>> FetchUsers();
    }
}
