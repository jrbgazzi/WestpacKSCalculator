using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Westpac.PageMethods
{
    public class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }

        //custom page load with wait
        public void WaitForPageToLoad()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        //custom find element method with wait
        public IWebElement GetElement(By locator)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(x => Driver.FindElement(locator).Displayed);
            return Driver.FindElement(locator);
        }

        //custom find elements method with wait
        public IList<IWebElement> GetElements(By locator)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(x => Driver.FindElements(locator).First().Displayed);
            return Driver.FindElements(locator);
        }

        //custom click element method with wait
        public void ClickElement(IWebElement element)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
            element.Click();
        }

        //custom send keys method with clear before sending key
        public void SendKeys(IWebElement element, string inputData)
        {
            element.Clear();
            element.SendKeys(inputData);
        }

        //custom wait until element is not found
        public bool WaitUntilElementNotFound(By element, int numberOfTry = 0)
        {
            var isElementFound = true;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            for (int retry = 0; retry < numberOfTry; retry++)
            {
                var elems = Driver.FindElements(element);
                if (elems.Count == 0) isElementFound = false;
            }
            return isElementFound;
        }

        public string GetText(IWebElement element)
        {
            return element.Text;
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }

        public bool IsElementEnabled(By locator)
        {
            return Driver.FindElement(locator).Enabled;
        }
        
    }
}
