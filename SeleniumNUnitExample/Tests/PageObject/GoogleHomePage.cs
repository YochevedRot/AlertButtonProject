using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample.Tests.PageObject
{
    internal class GoogleHomePage
    {
        private IWebDriver driver;
        public GoogleHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Search (string id, string query)
        {
        IWebElement searchBox = driver.FindElement(By.Id(id));
        searchBox.SendKeys(query);
        searchBox.Submit();
        }

    }
        
}
