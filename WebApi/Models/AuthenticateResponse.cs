using System;
using WebApi.Entities;

namespace WebApi.Models
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public bool Authenticated { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, bool authenticated, DateTime expirationDate, string token)
        {
            Username = user.Username;
            Authenticated = authenticated;
            ExpirationDate = expirationDate;
            Token = token;
        }
    }
}