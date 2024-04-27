using UserManagementSystem.Data;

namespace UserManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dbContext;

        public UserService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _dbContext.User.ToListAsync();
            return users;
        }

        public async Task<User?> GetSingleUserAsync(int id)
        {
            var user = await _dbContext.User.FindAsync(id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserAsync(int id, User request)
        {
            var user = await _dbContext.User.FindAsync(id);
            if (user is null)
            {
                return null;
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;

            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User?> DeleteUserAsync(int id)
        {
            var user = await _dbContext.User.FindAsync(id);
            if (user is null)
            {
                return null;
            }

            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
