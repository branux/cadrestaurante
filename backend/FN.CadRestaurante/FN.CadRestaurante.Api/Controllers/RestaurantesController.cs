using FN.CadRestaurante.Api.Models;
using FN.CadRestaurante.Domain.Commands.RestauranteCommand;
using FN.CadRestaurante.Domain.Contracts.Infra;
using FN.CadRestaurante.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FN.CadRestaurante.Api.Controllers
{
    [Route("api/v1/restaurantes")]
    public class RestaurantesController : BaseController
    {

        private readonly IRestauranteRepository _restauranteRepo;
        private readonly RestauranteCommandHandler _handler;

        public RestaurantesController(
            IUnitOfWork uow,
            RestauranteCommandHandler handler,
            IRestauranteRepository restauranteRepo) : base(uow)
        {
            _handler = handler;
            _restauranteRepo = restauranteRepo;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var dados = await _restauranteRepo
                .ObterAsync()
                .ConfigureAwait(false);

            return Json(
                new DadosDefaultVM(
                    dados.Select(u => new
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        DataCadastro = u.DataCadastro
                    })
                    , true));
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> Post([FromBody]AddRestauranteCommand command)
        {
            _handler.Handle(command);
            return ReturnResponseCommit(command, _handler.Notifications, HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> Put(Guid id,[FromBody]EditRestauranteCommand command)
        {
            _handler.Handle(command);
            return ReturnResponseCommit(command, _handler.Notifications, HttpStatusCode.OK);
        }
    }
}
