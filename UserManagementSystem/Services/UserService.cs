using UserManagementSystem.Data;
using UserManagementSystem.Services.Exceptions;

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
            try
            {
                var users = await _dbContext.User.ToListAsync();
                return users;
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<User?> GetSingleUserAsync(int id)
        {
            try
            {
                var user = await _dbContext.User.FindAsync(id);
                return user;

            } catch (NotFoundException e)
            {
                throw new NotFoundException(e.Message);
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            try
            {
                _dbContext.User.Add(user);
                await _dbContext.SaveChangesAsync();

                return user;
            } catch (NotFoundException e)
            {
                throw new NotFoundException(e.Message);
            }
        }

        public async Task<User?> UpdateUserAsync(int id, User request)
        {
            try
            {
                var user = await _dbContext.User.FindAsync(id);

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.Password = request.Password;

                await _dbContext.SaveChangesAsync();

                return user;
            } catch (NotFoundException e)
            {
                throw new NotFoundException(e.Message);
            } catch (DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        public async Task<User?> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _dbContext.User.FindAsync(id);
                _dbContext.User.Remove(user);

                await _dbContext.SaveChangesAsync();

                return user;
            } catch (NotFoundException e)
            {
                throw new NotFoundException(e.Message);
            }
        }
    }
}
