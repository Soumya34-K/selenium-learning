using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace SeleniumLearning
{
    [Parallelizable(ParallelScope.Self)]

    public class SortWebTable
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
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";

        }
        [Test]
        public void Sorttable()
        {
            ArrayList a = new ArrayList();
            SelectElement dd = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dd.SelectByValue("20");

            //get all the veggies into aaraylist a

           IList <IWebElement> veggies= driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }

            //sort the arraylist a

            foreach(string element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            TestContext.Progress.WriteLine("After Sorting");
            a.Sort();
            foreach (string element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            // Click on coloumn

            driver.FindElement(By.CssSelector("th[aria-label*='fruit name']")).Click();

            //Grabing the elements again after clicking coloumn

            ArrayList b = new ArrayList();
            IList<IWebElement> SortedVeggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach (IWebElement veggie in SortedVeggies)
            {
                b.Add(veggie.Text);
            }

            //compare arraylist a and b

            Assert.AreEqual(a,b);
            driver.Close();








        }
    }
}
