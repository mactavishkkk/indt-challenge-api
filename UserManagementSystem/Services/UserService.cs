namespace UserManagementSystem.Services
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>
        {
            new User {
                Id = 1,
                FirstName = "Isaías",
                LastName = "Leite",
                Email = "isaias@gmail.com",
                Password = "123",
                IsAdmin = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new User {
                Id = 2,
                FirstName = "Gabriela",
                LastName = "One",
                Email = "gabi@gmail.com",
                Password = "456",
                IsAdmin = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        };

        public List<User> GetAllUsersAsync()
        {
            return users;
        }

        public User GetSingleUserAsync(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public User CreateUserAsync(User user)
        {
            users.Add(user);
            return user;
        }

        public User UpdateUserAsync(int id, User request)
        {
            var user = users.Find(x => x.Id == id);
            if (user is null)
            {
                return null;
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;

            return user;
        }
        public User DeleteUserAsync(int id)
        {
            var user = users.Find(x => x.Id == id);
            if (user is null)
            {
                return null;
            }
            users.Remove(user);
            return user;
        }
    }
}
