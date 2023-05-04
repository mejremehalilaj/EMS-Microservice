using UserService.API.Interfaces;
using UserService.API.Models;
using UserService.API.UserService.Access;

namespace UserService.API.UserService.Business
{
    public class UserManager:IUserManager
    {
        private readonly IUser _context;

        public UserManager(IUser _context)
        {
            this._context = _context;
        }

        public async Task<List<UserModel>> FetchUsers()
        {
            return await _context.GetUsers();
        }
    }
}
