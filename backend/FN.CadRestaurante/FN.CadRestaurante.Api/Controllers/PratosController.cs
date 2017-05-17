using FN.CadRestaurante.Api.Models;
using FN.CadRestaurante.Domain.Commands.PratoCommand;
using FN.CadRestaurante.Domain.Contracts.Infra;
using FN.CadRestaurante.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FN.CadRestaurante.Api.Controllers
{
    [Route("api/v1/pratos")]
    public class PratosController : BaseController
    {

        private readonly IPratoRepository _pratoRepo;
        private readonly PratoCommandHandler _handler;

        public PratosController(
            IUnitOfWork uow,
            PratoCommandHandler handler,
            IPratoRepository restauranteRepo) : base(uow)
        {
            _handler = handler;
            _pratoRepo = restauranteRepo;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var dados = await _pratoRepo
                .ObterAsync()
                .ConfigureAwait(false);

            return Json(
                new DadosDefaultVM(
                    dados.Select(u => new
                    {
                        Id = u.Id,
                        Nome = u.Nome,
                        Preco = u.Preco,
                        RestauranteId = u.RestauranteId,
                        DataCadastro = u.DataCadastro
                    })
                    , true));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var dados = await _pratoRepo
                .ObterAsync(id)
                .ConfigureAwait(false);

            if (dados == null)
                return NotFound();

            return Json(
                new DadosDefaultVM(
                    new
                    {
                        Id = dados.Id,
                        Nome = dados.Nome,
                        Preco = dados.Preco,
                        RestauranteId = dados.RestauranteId,
                        DataCadastro = dados.DataCadastro
                    }
                    , true));
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> Post([FromBody]AddPratoCommand command)
        {
            _handler.Handle(command);
            return ReturnResponseCommit(command, _handler.Notifications, HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IActionResult> Put(Guid id, [FromBody]EditPratoCommand command)
        {
            command.Id = id;
            _handler.Handle(command);
            return ReturnResponseCommit(command, _handler.Notifications, HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<IActionResult> Delete(Guid id)
        {
            var command = new DelPratoCommand(id);
            _handler.Handle(command);
            return ReturnResponseCommit(command, _handler.Notifications, HttpStatusCode.NoContent);
        }
    }
}
