using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Models;
using Xunit;

namespace WebApiTest.WebApi.User
{
    public class ValidatePassword
    {
        private readonly UsersController _controller = new UsersController(new Mock.SrvUserMock());

        [Fact]
        public void ValidatePassword_True()
        {
            var result = _controller.ValidatePassword(new PasswordRequest { Password = "ABCDEFghijkb$c2" }) as OkObjectResult;
            Assert.Equal(true, result.Value);
        }

        [Fact]
        public void ValidatePassword_False()
        {
            var result = _controller.ValidatePassword(new PasswordRequest { Password = "123test" }) as OkObjectResult;
            Assert.Equal(false, result.Value);
        }
    }
}
