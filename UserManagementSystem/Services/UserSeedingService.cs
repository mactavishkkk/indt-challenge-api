using UserManagementSystem.Data;

namespace UserManagementSystem.Services
{
    public class UserSeedingService
    {
        private DataContext _context;

        public UserSeedingService(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.User.Any())
            {
                return; // Database has been seeded
            }

            User user = new User
            {
                Id = 1, FirstName = "Marcus", LastName = "Silva", Email = "marcus@gmail.com",
                Password = "password", IsAdmin = false, Status = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            };
            User userTwo = new User
            {
                Id = 2, FirstName = "Anderson", LastName = "Cunha", Email = "andersongmail.com",
                Password = "password", IsAdmin = false, Status = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            };
            User userThree = new User
            {
                Id = 3, FirstName = "Maraiza", LastName = "Onete", Email = "maraiza@gmail.com",
                Password = "password", IsAdmin = true, Status = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            };
            User userFour = new User
            {
                Id = 4, FirstName = "Ionete", LastName = "Onete", Email = "onete@gmail.com",
                Password = "password", IsAdmin = true, Status = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            };
            User userFive = new User
            {
                Id = 5, FirstName = "Francisco", LastName = "Souto", Email = "francisco@gmail.com",
                Password = "password", IsAdmin = false, Status = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow
            };

            _context.User.AddRange(user, userTwo, userThree, userFour, userFive);
            _context.SaveChanges();
        }
    }
}