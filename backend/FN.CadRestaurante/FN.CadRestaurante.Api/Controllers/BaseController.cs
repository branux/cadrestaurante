using FN.CadRestaurante.Domain.Contracts.Infra;
using FN.CadRestaurante.Domain.FluentValidator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FN.CadRestaurante.Api.Controllers
{
    public class BaseController : Controller
    {

        private IUnitOfWork _uow;
        public BaseController(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        protected Task<IActionResult> ReturnResponseCommit(
            object result, IEnumerable<Notification> notifications, HttpStatusCode statusCode
            )
        {
            if (!notifications.Any())
            {

                try
                {
                    _uow.Commit();
                    Response.StatusCode = (int)statusCode;
                    return Task.FromResult<IActionResult>(Json(new { success = true, data = result }));
                }
                catch
                {
                    Response.StatusCode = 500;
                    return Task.FromResult<IActionResult>(Json(new { success = false, errors = new string[] { "Ocorreu uma falha interna no servidor" } }));
                }
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Task.FromResult<IActionResult>(Json(new { success = false, errors = notifications }));
        }
    }
}
