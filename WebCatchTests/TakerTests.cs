using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

using WebCatch.EntityModel;


namespace WebCatchTests
{
    public class TakerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private const string receitaUrl = "https://receita.economia.gov.br/orientacao/tributaria/cadastros/cadastro-nacional-de-pessoas-juridicas-cnpj/dados-publicos-cnpj";
        private const string receitaRegex = "http.?(.*?)DADOS_ABERTOS_CNPJ(.*?).zip";
        private const string path = @"I:\\tmp";
        private const string extension = ".zip";

        [Test]
        public void LinksReceitaFederal()
        {
            WebCatch.LinkSolver ls = new WebCatch.LinkSolver();
            var links = ls.FindLinks(receitaUrl, receitaRegex);

            List<References> item = new List<References>();
            item.Add(links.FirstOrDefault());

            WebCatch.Taker taker = new WebCatch.Taker();
            taker.DownloadItems(item, path, extension);

            Assert.Pass();

        }
    }
}