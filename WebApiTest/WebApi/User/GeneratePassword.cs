using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using Xunit;

namespace WebApiTest.WebApi.User
{
    public class GeneratePassword
    {
        private readonly UsersController _controller = new UsersController(new Mock.SrvUserMock());

        [Fact]
        public void GeneratePassword_Ok()
        {
            Assert.IsType<OkObjectResult>(_controller.GeneratePassword());
        }
    }
}
