using NUnit.Framework;

using WebCatch.EntityModel;


namespace WebCatchTests
{
    public class LinkSolverTest
    {
        [SetUp]
        public void Setup()
        {
        }

        private string receitaUrl = "https://receita.economia.gov.br/orientacao/tributaria/cadastros/cadastro-nacional-de-pessoas-juridicas-cnpj/dados-publicos-cnpj";
        private string receitaRegex = "http.?(.*?)DADOS_ABERTOS_CNPJ(.*?).zip";

        [Test]
        public void LinksReceitaFederalTest()
        {
            WebCatch.LinkSolver ls = new WebCatch.LinkSolver();
            var links = ls.FindLinks(receitaUrl, receitaRegex);
            Assert.IsTrue(links.Count >0 );
        }
    }
}