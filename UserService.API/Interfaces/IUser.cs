using UserService.API.Models;

namespace UserService.API.Interfaces
{
    public interface IUser
    {
        Task<List<UserModel>> GetUsers();
    }
}
