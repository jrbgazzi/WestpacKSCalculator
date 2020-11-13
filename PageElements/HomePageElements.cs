using OpenQA.Selenium;

namespace Westpac.PageElements
{
    public class HomePageElements
    {
        public HomePageElements()
        {

        }

        public By headerMenu = By.XPath("//nav[contains(@class, 'clearfix sw-header-navbar')]");
        public By uberMenu = By.Id("ubermenu-ps");
        public By uberMenuItems = By.XPath("//li[contains(@class, 'sw-ubermenu-section')]");
        public By ksCalcBtn = By.Id("ubermenu-item-cta-kiwisaver-calculators-ps");       

    }
}
