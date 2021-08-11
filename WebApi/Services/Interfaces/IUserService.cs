using System;
using WebApi.Entities;
using WebApi.Models;

namespace WebApi.Services.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);
        bool ValidatePassword(string password);
        string GeneratePassword();
    }
}
