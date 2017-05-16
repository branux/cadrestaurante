using FN.CadRestaurante.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FN.CadRestaurante.UnitTest.Domain.Entities
{
    [TestClass]
    public class RestauranteTest
    {
        [TestMethod]
        [TestCategory("Domain | Entities | Restaurante | Add")]
        public void DadoUmNomeNuloDeveraRetornarUmaNotificacao()
        {
            var restaurante = new Restaurante(null);
            Assert.AreEqual(1, restaurante.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Domain | Entities | Restaurante | Add")]
        public void DadoUmNomeComMaisDeCemCaracteresDeveraRetornarUmaNotificacao()
        {
            var nome = @"1234567890123456789012345678901234
                            567890123456789012345678901234567890
                            1234567890123456789012345678901";
            var restaurante = new Restaurante(nome);
            Assert.AreEqual(1, restaurante.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Domain | Entities | Restaurante | Add")]
        public void DadoUmNomeComMenosDeTresCaracteresDeveraRetornarUmaNotificacao()
        {
            var nome = "ab";
            var restaurante = new Restaurante(nome);
            Assert.AreEqual(1, restaurante.Notifications.Count);
        }




        [TestMethod]
        [TestCategory("Domain | Entities | Restaurante | Edit")]
        public void DadoUmNomeNuloDeveraRetornarUmaNotificacaoQuandoAlterado()
        {
            var restaurante = new Restaurante("Nome válido");
            restaurante.Alterar(null);
            Assert.AreEqual(1, restaurante.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Domain | Entities | Restaurante | Edit")]
        public void DadoUmNomeComMaisDeCemCaracteresDeveraRetornarUmaNotificacaoQuandoAlterado()
        {
            var restaurante = new Restaurante("Nome válido");
            restaurante.Alterar(@"1234567890123456789012345678901234
                            567890123456789012345678901234567890
                            1234567890123456789012345678901");
            Assert.AreEqual(1, restaurante.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Domain | Entities | Restaurante | Edit")]
        public void DadoUmNomeComMenosDeTresCaracteresDeveraRetornarUmaNotificacaoQuandoAlterado()
        {
            var restaurante = new Restaurante("Nome válido");
            restaurante.Alterar("ab");
            Assert.AreEqual(1, restaurante.Notifications.Count);
        }

    }
}
