using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLearning
{
    public class SelectClass
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            //implicit wait statement
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void Selectdropdown()
        {
            IWebElement dropdown= driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement dd=new SelectElement(dropdown);
            dd.SelectByIndex(0);
            Thread.Sleep(1000);
            dd.SelectByValue("teach");
            Thread.Sleep(1000);
            dd.SelectByText("Consultant");


            IList <IWebElement>  radios  = driver.FindElements(By.CssSelector("input[type='radio']"));

            foreach (IWebElement radiobutton in radios)
            {

                if (radiobutton.GetAttribute("value").Equals("user"))
                {

                    radiobutton.Click();
                }
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));

            driver.FindElement(By.Id("okayBtn")).Click();
           bool result= driver.FindElement(By.Id("usertype")).Selected;
            Assert.That(result, Is.True);

        }
    }
}
