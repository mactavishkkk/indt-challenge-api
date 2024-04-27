using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Controllers;
using UserManagementSystem.Models;
using UserManagementSystem.Services;

namespace UsermanagementSystem.Tests.Controller
{
    public class UserControllerTest
    {
        private readonly IUserService _userService;
        private readonly User userObject = new User
        {
            Id = 1, FirstName = "test", LastName = "unix", Email = "test@gmail.com",
            Password = "123", IsAdmin = false, Status = false, CreatedAt = DateTime.Today, UpdatedAt = DateTime.Today
        };

        public UserControllerTest()
        {
            _userService = A.Fake<IUserService>();
        }

        [Fact]
        public void GetAllUsersAsync_Success()
        {
            // Arrange
            var usersList = A.Fake<List<User>>();
            A.CallTo(() => _userService.GetAllUsersAsync()).Returns(Task.FromResult(usersList));

            var controller = new UserController(_userService);

            // Act
            var result = controller.GetAllUsersAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ActionResult<List<User>>>>();
        }

        [Fact]
        public async Task GetSingleUserAsync_Success()
        {
            // Arrange

            var expectedUser = userObject;
            A.CallTo(() => _userService.GetSingleUserAsync(expectedUser.Id)).Returns(Task.FromResult(expectedUser));

            var controller = new UserController(_userService);

            // Act
            var result = await controller.GetSingleUserAsync(expectedUser.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<User>>();
        }

        [Fact]
        public async Task CreateUserAsync_Success()
        {
            // Arrange
            var user = A.Fake<User>();
            A.CallTo(() => _userService.CreateUserAsync(user)).Returns(Task.FromResult(user));

            var controller = new UserController(_userService);

            // Act
            var result = await controller.CreateUserAsync(user);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<User>>();

        }

        [Fact]
        public async Task UpdateUserAsync_Success()
        {
            // Arrange
            int userId = 1;
            var updatedUser = userObject;
            A.CallTo(() => _userService.UpdateUserAsync(userId, A<User>.Ignored)).Returns(Task.FromResult(updatedUser));

            var controller = new UserController(_userService);

            // Act
            var result = await controller.UpdateUserAsync(userId, updatedUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<User>>();
        }

        [Fact]
        public async Task DeleteUserAsync_Success()
        {
            // Arrange
            int userId = 1;
            var deletedUser = userObject;
            A.CallTo(() => _userService.DeleteUserAsync(userId)).Returns(Task.FromResult(deletedUser));

            var controller = new UserController(_userService);

            // Act
            var result = await controller.DeleteUserAsync(userId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<User>>();
        }

    }
}
