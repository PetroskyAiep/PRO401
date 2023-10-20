using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PRO401.DTO.AccountDTO;
using PRO401.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PRO401.Controllers
{
    public class AccountController : ControllerBase
    {
        private UserManager<Usuario> _userManager;
        private IConfiguration _configuration;
        private SignInManager<Usuario> _signInManager;

        public AccountController(UserManager<Usuario> userManager,  IConfiguration configuration, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<AuthenticationResponse>> Register(UserCredentials userCredentials,  UsuarioCreateDTO usuario)
        {
            var user = new Usuario { 
                UserName = userCredentials.Email, 
                Email = userCredentials.Email, 
                Run = usuario.Run,
                Nombres = usuario.Nombres,
                Apellidos = usuario.Apellidos,
                FechaNacimiento = usuario.FechaNacimiento,
                ComunaResidenciaId = usuario.ComunaResidenciaId,
                ComunaTrabajoId = usuario.ComunaTrabajoId,
                EstadoRegistroId = usuario.EstadoRegistroId,
                TipoTrabajoId = usuario.TipoTrabajoId,
    };
            var result = await _userManager.CreateAsync(user, userCredentials.Password);
            if (result.Succeeded)
            {
                return BuildToken(userCredentials);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(UserCredentials userCredentials)
        {
            var result = await _signInManager.PasswordSignInAsync(userCredentials.Email, userCredentials.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return BuildToken(userCredentials);
            }
            else
            {
                return BadRequest("Login Incorrecto");
            }
        }

        [HttpGet("user")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult User()
        {
            var response = new UserInfo();
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            response.Email = email;
            response.Ok = true;
            return Ok(response);
        }

        private AuthenticationResponse BuildToken(UserCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", userCredentials.Email),
                new Claim("otra informacion", "lo que yo quiera")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtkey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(1);
            var securityToken = new JwtSecurityToken(
                issuer:null,
                audience:null,
                claims:claims,
                expires:expiration,
                signingCredentials:creds
                );

            return new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration,
            };
        }

    }
}
