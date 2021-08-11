using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Models;
using Xunit;

namespace WebApiTest.WebApi.User
{
    public class Authenticate
    {
        private readonly UsersController _controller = new UsersController(new Mock.SrvUserMock());

        [Fact]
        public void Authenticate_Ok()
        {
            Assert.IsType<OkObjectResult>(_controller.Authenticate(new AuthenticateRequest { Username = "test", Password = "test" }));
        }

        [Fact]
        public void Authenticate_BadRequest()
        {
            Assert.IsType<BadRequestObjectResult>(_controller.Authenticate(new AuthenticateRequest { Username = "test", Password = "erro" }));
        }
    }
}
