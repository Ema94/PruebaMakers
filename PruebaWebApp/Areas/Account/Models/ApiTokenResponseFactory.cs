using PruebaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApp.Areas.Account.Models
{
    public static  class ApiTokenResponseFactory
    {
        public static ApiTokenResponse UserError()
        {
            return new ApiTokenResponse()
            {
                Code = 1001,
                Message="La transaccion fallo",
                Description = "El usuario no existe en la plataforma"
            };
        }

        public static ApiTokenResponse Ok()
        {
            return new ApiTokenResponse()
            {
                Code = 1000,
                Message="Transaccion Exitosa",
                Description = "Token generado con exito"
            };
        }
    }
}
