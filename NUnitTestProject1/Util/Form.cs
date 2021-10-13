using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace NUnitTestProject1.Util
{
    class Form
    {
        private static Form form = null;
        private IWebDriver driver;

        private Form()
        {
            // Seta a localização do arquivo ChromeDriver.exe
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            // Abre a URL
            driver.Navigate().GoToUrl("https://forms.gle/QP7TiRSRMRVM7Zkv9");
            driver.Manage().Window.Size = new System.Drawing.Size(1024,720);
            driver.Manage().Window.Position = new System.Drawing.Point(350, 8);
        }

        // Permite somente uma instância do Form (Singleton)
        public static Form GetInstance()
        {
            if (form==null)
            {
                form = new Form();
            }
            return form;
        }

        public IWebDriver GetDriver()
        {
            return this.driver;
        }
    }
}
