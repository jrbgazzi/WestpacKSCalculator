using OpenQA.Selenium;

namespace Westpac.PageElements
{
    class KiwiSaverCalculatorPageElements
    {
        public KiwiSaverCalculatorPageElements()
        {

        }

        public By getStartedBtn = By.XPath("//a[(text()='" + "Click here to get started." + "')]");
    }
}
