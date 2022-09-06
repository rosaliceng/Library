using LibraryWebAPI.Models;

namespace LibraryWebAPI.Services.Users
{
    public interface IUserService
    {
        User UserCreate(User model);
        User UserUpdate(int userId, User model);
        User UserDelete(int userId);
    }
}
