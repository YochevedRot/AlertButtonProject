using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace SeleniumNUnitExample.Tests
{
    [TestFixture]
    public class GoogleSearchTest
    {

        private IWebDriver driver;

        public GoogleSearchTest()
        {

        }

        [SetUp]
        public void SetUp()
        {
            string path = @"C:\Users\user\Downloads\GoogleSearchTest - main\SeleniumNUnitExample\drivers";
            driver = new ChromeDriver(path);
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestGoogleSearch()
        {
            //1.Navigate to the Google homepage.
            driver.Navigate().GoToUrl("https://www.google.com");

            //2.Verify the title of the page.
            ClassicAssert.AreEqual("Google", driver.Title);

            //3.Find the search box using its name attribute.
            IWebElement searchBox = driver.FindElement(By.Id("realbox"));

            //4.Enter the search term "Selenium WebDriver".
            searchBox.SendKeys("Selenium WebDriver");

            //5.Submit the search.
            searchBox.Submit();

            //6.Wait for the results page to load and verify the title.
            Thread.Sleep(2000);
            ClassicAssert.IsTrue(driver.Title.Contains("Selenium WebDriver"));

            //7.Verify that search results are displayed.
            IWebElement results = driver.FindElement(By.Id("search"));
            ClassicAssert.IsTrue(results.Displayed);

            //8.Click on the first result link.
            IWebElement first = driver.FindElement(By.CssSelector("h3"));
            first.Click();

            //9.Verify the title of the new page.
            ClassicAssert.IsTrue(driver.Title.Contains("WebDriver"));

            //10.Navigate back to the Google search results page.
            driver.Navigate().Back();


            //11.Verify the search box still contains the search term.
            ClassicAssert.IsTrue(searchBox.Displayed);
            ClassicAssert.IsTrue(driver.Title.Contains("Selenium WebDriver"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
