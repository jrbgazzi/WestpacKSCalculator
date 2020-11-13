using OpenQA.Selenium;
using Westpac.PageElements;

namespace Westpac.PageMethods
{
    public class KiwiSaverCalculatorPage : BasePage
    {
        private KiwiSaverCalculatorPageElements _ksCalcPageElements;

        
        public KiwiSaverCalculatorPage(IWebDriver driver) : base(driver)
        {
            _ksCalcPageElements = new KiwiSaverCalculatorPageElements();
        }

        public void OpenKiwiSaverRetirementCalculator()
        {
            ClickElement(GetElement(_ksCalcPageElements.getStartedBtn));
        }


    }
}
