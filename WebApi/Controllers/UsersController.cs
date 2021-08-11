using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Autenticação de usuário.
        /// </summary>
        /// <returns>Retorna a classe de usuário de login válido com token e demais informações</returns>
        /// <response code="200">Informações de usuário logado</response>
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Usuário e/ou senha inválido(s)" });

            return Ok(response);
        }

        /// <summary>
        /// Validação de senha.
        /// </summary>
        /// <returns>Retorna verdadeiro ou falso para a senha informada seguindo os critérios definido no projeto.</returns>
        /// <response code="200">Verdadeiro ou falso para validação de senha</response>
        [Authorize]
        [HttpPost("validatePassword")]
        public IActionResult ValidatePassword(PasswordRequest passwordRequest)
        {
            return Ok(_userService.ValidatePassword(passwordRequest.Password));
        }

        /// <summary>
        /// Geração de senha.
        /// </summary>
        /// <returns>Retorna uma senha gerada automaticamente seguindos os critérios definido no projeto.</returns>
        /// <response code="200">Senha gerada automaticamente</response>
        [Authorize]
        [HttpGet("generatePassword")]
        public IActionResult GeneratePassword()
        {
            return Ok(_userService.GeneratePassword());
        }
    }
}
