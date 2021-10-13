using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace NUnitTestProject1.Pages
{
    class FormPage
    {
        private IWebDriver driver;
        private int tempo = 2000;

        // Construtor para setar a variável driver
        public FormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Recebe o nome e a opção e envia o formulário
        public void EnviaForm(String nome, String opcao)
        {
            driver.FindElement(By.CssSelector(".quantumWizTextinputPapertextareaInput")).Clear();
            driver.FindElement(By.CssSelector(".quantumWizTextinputPapertextareaInput")).SendKeys(nome);
            Thread.Sleep(tempo);

            if (opcao != "")
            {
                if (opcao == "1") {
                    driver.FindElement(By.CssSelector("#i9 .appsMaterialWizToggleRadiogroupOffRadio")).Click();
                    driver.FindElement(By.CssSelector("#i9 .appsMaterialWizToggleRadiogroupOffRadio")).Click();
                }
                if (opcao == "2") {
                    driver.FindElement(By.CssSelector("#i12 .appsMaterialWizToggleRadiogroupOffRadio")).Click();
                    driver.FindElement(By.CssSelector("#i12 .appsMaterialWizToggleRadiogroupOffRadio")).Click();
                }
            }
            Thread.Sleep(tempo);

            driver.FindElement(By.CssSelector(".appsMaterialWizButtonPaperbuttonFilled .appsMaterialWizButtonPaperbuttonLabel")).Click();
            Thread.Sleep(tempo);
        }

        // Exibe a mensagem de limpar formulário
        public void ExibeLimpaForm()
        {
            driver.FindElement(By.CssSelector(".appsMaterialWizButtonPaperbuttonText .appsMaterialWizButtonPaperbuttonLabel")).Click();
        }

    }
}
