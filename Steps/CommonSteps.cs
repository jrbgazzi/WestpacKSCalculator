using NUnit.Framework;
using TechTalk.SpecFlow;
using Westpac.DataModel;
using Westpac.PageMethods;
using Westpac.Copy;

namespace Westpac.Steps
{
    [Binding]
    public class CommonSteps : BaseSteps
    {
        HomePage _homePage;
        KiwiSaverCalculatorPage _ksCalcPage;
        KiwiSaverRetirementCalculatorPage _ksRetCalcPage;
        CopyPage _copyPage;

        public CommonSteps(ContextObject contextObject) : base(contextObject)
        {
            _homePage = new HomePage(ContextObject.Driver);
            _ksCalcPage = new KiwiSaverCalculatorPage(ContextObject.Driver);
            _ksRetCalcPage = new KiwiSaverRetirementCalculatorPage(ContextObject.Driver, ContextObject);
            _copyPage = new CopyPage();
        }

        [Given(@"I am in the KiwiSaver Retirement Calculator Page")]
        public void GivenIAmInTheKiwiSaverRetirementCalculatorPage()
        {
            _homePage.NavigateToKiwiSaverCalculatorPage();
            _ksCalcPage.OpenKiwiSaverRetirementCalculator();
            _ksRetCalcPage.SwitchToCalculatorIframe();
            Assert.AreEqual(_copyPage.ksCalcPageUrl, _ksRetCalcPage.GetCurrentUrl());
        }
    }
}
