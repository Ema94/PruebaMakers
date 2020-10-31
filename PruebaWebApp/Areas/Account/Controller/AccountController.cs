using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PruebaWebApp.Areas.Account.Models;

namespace PruebaWebApp.Areas.Account.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //Por cuestiones de tiempo no realizare la persistencia de usuarios, solo se podra logear con usuario estatico, disculpas
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration config;

        public AccountController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpPost]
        public ApiTokenResponse Login(UsuarioModel usuarioModel)
        {
            var validateUsuario = ValidateUsuario(usuarioModel);
            if (!validateUsuario)
            {
                 ApiTokenResponseFactory.UserError();
            }

            var fechavencimiento = DateTime.Now.AddDays(1);//el 1 deberia ir en el appsettings.json

            var token = GenerateJSONWebToken(fechavencimiento);

            var response = ApiTokenResponseFactory.Ok();

            response.Description = "Token generado con exito";
            response.Token = token;
            response.FechaVencimiento = fechavencimiento;
            return response;
        }
        private string GenerateJSONWebToken(DateTime fechaVencimiento)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokendesc = new SecurityTokenDescriptor()
            {

                Expires = fechaVencimiento,
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var strToken = tokenHandler.CreateToken(tokendesc);
            return new JwtSecurityTokenHandler().WriteToken(strToken);
        }
        private bool ValidateUsuario(UsuarioModel usuarioModel)
        {
            if(usuarioModel.User =="admin" 
                && usuarioModel.Password == "Password")
            {
                return true;
            }
            return false;
        }

       
    }
}
