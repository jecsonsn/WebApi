using System;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApiTest.Mock
{
    class SrvUserMock : IUserService
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            if (!(model.Username == "test" && model.Password == "test")) return null;

            return new AuthenticateResponse(new User { Username = model.Username}, true, DateTime.Now.AddMinutes(5),"Brazil");
        }

        public string GeneratePassword()
        {
            return PasswordHelper.GenerateRandomPassword();
        }

        public User GetById(int id)
        {
            return new User
            {
                Id = 1,
                Username = "test",
                Password = "test",
                FirstName = "Test",
                LastName = "test"
            };
        }

        public bool ValidatePassword(string password)
        {
            return PasswordHelper.PasswordIsValid(password);
        }
    }
}
