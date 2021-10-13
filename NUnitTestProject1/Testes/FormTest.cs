using NUnit.Framework;
using OpenQA.Selenium;
using NUnitTestProject1.Util;
using NUnitTestProject1.Pages;
using System.Threading;

namespace FormTest
{
    public class FormTest
    {
        private static IWebDriver driver = Form.GetInstance().GetDriver();
        private FormPage formPage = new FormPage(driver);
        private bool achou;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        // Verifica a mensagem para limpar o formulário
        public void Test1()
        {
            formPage.ExibeLimpaForm();
            Thread.Sleep(2000);
            achou = driver.PageSource.Contains("Limpar o formulário?") &&
                    driver.PageSource.Contains("Com isso, todas as respostas serão removidas. Não será possível desfazer esta ação.");
            Assert.True(achou);
            driver.FindElement(By.CssSelector(".appsMaterialWizButtonEl.appsMaterialWizButtonPaperbuttonEl.appsMaterialWizButtonPaperbuttonText.appsMaterialWizDialogPaperdialogDialogButton.isUndragged")).Click();
        }

        [Test]
        // Verifica se o nome é obrigatório
        public void Test2()
        {
            formPage.EnviaForm("", "");
            achou = driver.PageSource.Contains("Esta pergunta é obrigatória");
            Assert.True(achou);
        }

        [Test]
        // Verifica se o nome não permite menos que 10 caracteres
        public void Test3()
        {
            formPage.EnviaForm("Marcello", "");
            achou = driver.PageSource.Contains("Mínimo de 10 caracteres");
            Assert.True(achou);
        }

        [Test]
        // Verifica se os radio buttons são obrigatórios
        public void Test4()
        {
            formPage.EnviaForm("Marcello Polito", "");
            achou = driver.PageSource.Contains("Esta pergunta é obrigatória");
            Assert.True(achou);
        }

        [Test]
        // Envia o formulário
        public void Test5()
        {
            formPage.EnviaForm("Marcello Polito", "1");
            achou = driver.PageSource.Contains("Sua resposta foi registrada.");
            Assert.True(achou);
        }
    }
}