using Mapster;
using Microsoft.EntityFrameworkCore;
using UserService.API.Domain;
using UserService.API.Interfaces;
using UserService.API.Models;

namespace UserService.API.UserService.Access
{
    public class UserDto : IUser
    {
        private readonly UserDbContext _context;

        public UserDto(UserDbContext _context)
        {
            this._context = _context;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users.Adapt<List<UserModel>>();
        }
    }
}
