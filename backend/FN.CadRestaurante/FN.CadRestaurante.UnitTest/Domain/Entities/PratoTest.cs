using FN.CadRestaurante.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FN.CadRestaurante.UnitTest.Domain.Entities
{
    [TestClass]
    public class PratoTest
    {

        [TestMethod]
        [TestCategory("Domain | Entities | Prato | Add")]
        public void DadoUmNomeNuloDeveraRetornarUmaNotificacao()
        {
            var prato = new Prato(null,1M);
            Assert.AreEqual(1, prato.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Domain | Entities | Prato | Add")]
        public void DadoUmNomeComMaisDeCemCaracteresDeveraRetornarUmaNotificacao()
        {
            var nome = @"1234567890123456789012345678901234
                            567890123456789012345678901234567890
                            1234567890123456789012345678901";
            var prato = new Prato(nome,1M);
            Assert.AreEqual(1, prato.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Domain | Entities | Prato | Add")]
        public void DadoUmNomeComMenosDeTresCaracteresDeveraRetornarUmaNotificacao()
        {
            var nome = "ab";
            var prato = new Prato(nome, 1M);
            Assert.AreEqual(1, prato.Notifications.Count);
        }


        [TestMethod]
        [TestCategory("Domain | Entities | Prato | Add")]
        public void DadoUmPrecoMenorIgualaZeroDeveraRetornarUmaNotificacao()
        {
            var prato = new Prato("nome válido", 0M);
            Assert.AreEqual(1, prato.Notifications.Count);
        }




        [TestMethod]
        [TestCategory("Domain | Entities | Prato | Edit")]
        public void DadoUmNomeNuloDeveraRetornarUmaNotificacaoQuandoAlterado()
        {
            var prato = new Prato("nome válido", 1M);
            prato.Alterar(null, 1M);
            Assert.AreEqual(1, prato.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Domain | Entities | Prato | Edit")]
        public void DadoUmNomeComMaisDeCemCaracteresDeveraRetornarUmaNotificacaoQdoAlterao()
        {
            var prato = new Prato("nome válido", 1M);
            prato.Alterar(@"1234567890123456789012345678901234
                            567890123456789012345678901234567890
                            1234567890123456789012345678901",1M);
            Assert.AreEqual(1, prato.Notifications.Count);
        }

        [TestMethod]
        [TestCategory("Domain | Entities | Prato | Edit")]
        public void DadoUmNomeComMenosDeTresCaracteresDeveraRetornarUmaNotificacaoQdoAlterado()
        {
            var prato = new Prato("nome válido", 1M);
            prato.Alterar("ab",1M);
            Assert.AreEqual(1, prato.Notifications.Count);
        }


        [TestMethod]
        [TestCategory("Domain | Entities | Prato | Edit")]
        public void DadoUmPrecoMenorIgualaZeroDeveraRetornarUmaNotificacaoQdoAlterado()
        {
            var prato = new Prato("nome válido", 1M);
            prato.Alterar("nome válido", 0M);
            Assert.AreEqual(1, prato.Notifications.Count);
        }

    }
}
