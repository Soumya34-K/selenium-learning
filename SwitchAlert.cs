using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumLearning
{
    public class SwitchAlert
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            //implicit wait statement
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";

        }
        [Test]

        public void Alert()
        {
            String name = "Soumya";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayConfirm']")).Click();
           String alrttext= driver.SwitchTo().Alert().Text;
            StringAssert.Contains(name, alrttext);
            driver.SwitchTo().Alert().Accept();
            // driver.SwitchTo().Alert().Dismiss();
           // driver.SwitchTo().Alert().SendKeys("Soumya");
            
        }
        [Test]

        public void AutosuggestiondropDown()

        {
            driver.FindElement(By.CssSelector("#autocomplete")).SendKeys("ind");
            Thread.Sleep(3000);
           
           IList <IWebElement> options = driver.FindElements(By.CssSelector(".ui-menu-item div"));

            foreach (IWebElement option in options)
            {
                if (option.Text.Equals("India"))
 
                        option.Click();

            }

            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("#autocomplete")).GetAttribute("value"));

        }
        [Test]

        public void SelectDropDown()
        {
          IWebElement  dropdown = driver.FindElement(By.CssSelector("#dropdown-class-example"));

            SelectElement dd = new SelectElement(dropdown);
            dd.SelectByIndex(0);
            Thread.Sleep(2000);
            dd.SelectByValue("option3");
            dd.SelectByText("Option2");

        }
        [Test]

        public void Actions()

        {
            driver.Url = "https://rahulshettyacademy.com/";

            Actions act = new Actions(driver);
            act.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();
            act.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();
            
        }
        [Test]

        public void dragndrop()
        {
            driver.Url = "https://demoqa.com/droppable";
            Actions act = new Actions(driver);
           IWebElement Source = driver.FindElement(By.Id("draggable"));
           IWebElement Target = driver.FindElement(By.Id("droppable"));
           act.DragAndDrop(Source, Target).Perform();

        }

        [Test]

        public void Frames()
        {
            IWebElement frameid = driver.FindElement(By.Id("courses-iframe"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", frameid);

            //id, name,Index
            driver.SwitchTo().Frame("courses-iframe");
            //driver.FindElement(By.LinkText("Job Support")).Click();
            driver.FindElement(By.PartialLinkText("Access")).Click();
            //driver.FindElement(By.PartialLinkText("Learning")).Click();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        }





    }
}
