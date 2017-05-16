using FN.CadRestaurante.Domain.Contracts.Repositories;
using FN.CadRestaurante.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FN.CadRestaurante.UnitTest.Domain.Contracts.Repository
{
    [TestClass]
    public class BaseRepositoryTest
    {

        [TestMethod]
        [TestCategory("Domain | Contracts | Repository | IRepository")]
        public void DadoUmaEntidadeORepositorioDeveraPermitirObterUmaUnicaEntidade()
        {
            var repo = RepoFactorie();
            var entity = new EntityFake("Outro Campo");
            repo.Adicionar(entity);

            Assert.AreEqual(entity.Id, repo.Obter(entity.Id).Id);
        }

        [TestMethod]
        [TestCategory("Domain | Contracts | Repository | IRepository")]
        public void DadoUmaEntidadeORepositorioDeveraPermitirObterUmaUnicaEntidadeAsync()
        {
            var repo = RepoFactorie();
            var entity = new EntityFake("Outro Campo");
            repo.Adicionar(entity);

            Assert.AreEqual(entity.Id, (repo.ObterAsync(entity.Id)).Result.Id);
        }

        [TestMethod]
        [TestCategory("Domain | Contracts | Repository | IRepository")]
        public void DadoUmaEntidadeORepositorioDeveraPermitirObterTodasEntidades()
        {
            var repo = RepoFactorie();
            var entity = new EntityFake("Outro Campo");
            repo.Adicionar(entity);
            var entity2 = new EntityFake("Outro Campo");
            repo.Adicionar(entity2);

            Assert.AreEqual(2, repo.Obter().Count());
        }

        [TestMethod]
        [TestCategory("Domain | Contracts | Repository | IRepository")]
        public void DadoUmaEntidadeORepositorioDeveraPermitirObterTodasEntidadesAsync()
        {
            var repo = RepoFactorie();
            var entity = new EntityFake("Outro Campo");
            repo.Adicionar(entity);
            var entity2 = new EntityFake("Outro Campo");
            repo.Adicionar(entity2);

            Assert.AreEqual(2, (repo.ObterAsync()).Result.Count());
        }

        [TestMethod]
        [TestCategory("Domain | Contracts | Repository | IRepository")]
        public void DadoUmaEntidadeORepositorioDeveraPermitirAdicionar()
        {
            var repo = RepoFactorie();
            var atual = repo.Obter().Count();

            repo.Adicionar(new EntityFake("Outro Campo"));

            Assert.AreEqual(atual + 1, repo.Obter().Count());
        }

        [TestMethod]
        [TestCategory("Domain | Contracts | Repository | IRepository")]
        public void DadoUmaEntidadeORepositorioDeveraPermitirAtualizar()
        {
            var repo = RepoFactorie();
            var entity = new EntityFake("Outro Campo");
            repo.Adicionar(entity);

            entity.Alterar("Campo alterado");

            Assert.AreEqual("Campo alterado", repo.Obter(entity.Id).OutroCampo);
        }

        [TestMethod]
        [TestCategory("Domain | Contracts | Repository | IRepository")]
        public void DadoUmaEntidadeORepositorioDeveraPermitirExcluirUmaEntidade()
        {
            var repo = RepoFactorie();
            var entity = new EntityFake("Outro Campo");
            repo.Adicionar(entity);

            var countBefore = repo.Obter().Count();
            repo.Excluir(entity);

            Assert.AreEqual(countBefore - 1, repo.Obter().Count());
        }

        [TestMethod]
        [TestCategory("Domain | Contracts | Repository | IRepository")]
        public void DadoUmaEntidadeORepositorioDeveraPermitirExcluirUmaListaDeEntidade()
        {
            var repo = RepoFactorie();
            var entity = new EntityFake("Outro Campo");
            repo.Adicionar(entity);
            var entity2 = new EntityFake("Outro Campo");
            repo.Adicionar(entity2);

            var countBefore = repo.Obter().Count();
            var entities = new List<EntityFake>();
            entities.Add(entity);
            entities.Add(entity2);
            repo.Excluir(entities);

            Assert.AreEqual(countBefore - 2, repo.Obter().Count());
        }




        IRepository<EntityFake> _repo;
        private IRepository<EntityFake> RepoFactorie()
        {
            return _repo ?? new BaseRepositoryFake();
        }
    }

    public class BaseRepositoryFake : IRepository<EntityFake>
    {
        private readonly IList<EntityFake> _data =
            new List<EntityFake>();

        public void Adicionar(EntityFake entity)
        {
            _data.Add(entity);
        }

        public void Atualizar(EntityFake entity)
        {
            var update = Obter(entity.Id);
            update.Alterar(entity.OutroCampo);
        }

        public void Excluir(EntityFake entity)
        {
            _data.Remove(entity);
        }

        public void Excluir(IEnumerable<EntityFake> entities)
        {
            entities.ToList().ForEach(data => _data.Remove(data));
        }

        public IEnumerable<EntityFake> Obter()
        {
            return _data;
        }

        public EntityFake Obter(Guid key)
        {
            return _data.FirstOrDefault(x => x.Id == key);
        }

        public async Task<IEnumerable<EntityFake>> ObterAsync()
        {
            return await
                Task.FromResult(_data.ToList().AsEnumerable());
        }

        public async Task<EntityFake> ObterAsync(Guid key)
        {
            return await
                Task.FromResult(Obter(key));
        }

        public void Dispose()
        {
            return;
        }
    }

    public class EntityFake : Entity
    {
        public EntityFake(string outroCampo)
        {
            OutroCampo = outroCampo;
        }

        public string OutroCampo { get; private set; }

        public void Alterar(string outroCampo)
        {
            OutroCampo = outroCampo;
        }
    }
}
