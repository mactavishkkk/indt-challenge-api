namespace UserManagementSystem.Services
{
    public interface IUserService
    {
        List<User> GetAllUsersAsync();
        User GetSingleUserAsync(int id);
        User CreateUserAsync(User user);
        User UpdateUserAsync(int id, User request);
        User DeleteUserAsync(int id);
    }
}
