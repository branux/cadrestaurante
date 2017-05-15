using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FN.CadRestaurante.Api.Controllers
{
    [Route("api/v1/restaurantes")]
    public class RestaurantesController : Controller
    {

        [Route("")]
        public string Get()
        {
            return "Teste";
        }
    }
}
