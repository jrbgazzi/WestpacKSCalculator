using NUnit.Framework;
using TechTalk.SpecFlow;
using Westpac.DataModel;
using Westpac.PageMethods;
using Westpac.Copy;

namespace Westpac.Steps
{
    [Binding]
    public class InformationIconSteps : BaseSteps
    {
        private readonly KiwiSaverRetirementCalculatorPage _ksRetCalcPage;
        private readonly CopyPage _copy;

        public InformationIconSteps(ContextObject contextObject) : base(contextObject)
        {
            _ksRetCalcPage = new KiwiSaverRetirementCalculatorPage(ContextObject.Driver, ContextObject);
            _copy = new CopyPage();
        }

        [When(@"I click on the information icon for (.*)")]
        public void WhenIClickOnTheInformationIconForCalculatorElement(string element)
        {
            _ksRetCalcPage.ClickInformationIcon(element);
        }

        [Then(@"I am informed of what needs to be entered in the (.*)")]
        public void ThenIAmInformedOfWhatNeedsToBeEnteredInTheCalculatorElement(string element)
        {
            Assert.AreEqual(_copy.GetInfoTextCopy(element), _ksRetCalcPage.GetInformationIconText(element));
        }
    }
}
