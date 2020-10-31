using PruebaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApp.Areas.Account.Models
{
    public class ApiTokenResponse : BaseApiResponse
    {
        public string Token { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
