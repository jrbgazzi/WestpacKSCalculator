using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Westpac.PageElements;

namespace Westpac.PageMethods
{
    public class HomePage : BasePage
    {
        private HomePageElements _homePageElements;
        private IWebDriver _driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            _homePageElements = new HomePageElements();
        }

        public void NavigateToKiwiSaverCalculatorPage()
        {
            WaitForPageToLoad();
            SwitchToDefaultContent();

            //hover action on KiwiSaver menu
            Actions action = new Actions(_driver);

            var uberMenuItems = GetElements(_homePageElements.uberMenuItems);

            foreach(var item in uberMenuItems)
            {
                if (item.Text == "KiwiSaver")
                {
                    action.MoveToElement(item).Perform();
                    break;
                }
            }
            
            ClickElement(GetElement(_homePageElements.ksCalcBtn));
        }

    }

    
}
