using NUnit.Framework;
using TechTalk.SpecFlow;
using Westpac.DataModel;
using Westpac.PageMethods;
using Westpac.Copy;


namespace Westpac.Steps
{
    [Binding]
    public class KiwiSaverCalculatorSteps : BaseSteps
    {
        private readonly KiwiSaverRetirementCalculatorPage _ksRetCalcPage;
        private readonly CopyPage _copyPage;

        public KiwiSaverCalculatorSteps(ContextObject contextObject) : base(contextObject)
        {
            _ksRetCalcPage = new KiwiSaverRetirementCalculatorPage(ContextObject.Driver, ContextObject);
            _copyPage = new CopyPage();
        }

        [When(@"I fill up the calculator with my user profile as (.*)")]
        public void WhenIFillUpTheCalculatorWithMyUserProfileAsPersona(string persona)
        {
            _ksRetCalcPage.FillUpCalculatorWithUserProfile(persona);
        }

        [When(@"I enter (.*) in (.*)")]
        public void WhenIEnterTextinElement(string entry, string field)
        {
            _ksRetCalcPage.PopulateField(entry, field);
        }

        [When(@"I select (.*) in (.*)")]
        public void WhenISelectOptionInElement(string entry, string field)
        {
            _ksRetCalcPage.PopulateField(entry, field);
        }

        [Then(@"I am able to calculate my projected balances at retirement")]
        public void ThenIAmAbleToCalculateMyProjectedBalancesAtRetirement()
        {
            Assert.AreEqual(_copyPage.projectedBalBtnLabel, _ksRetCalcPage.GetProjectedBalanceButtonLabel());
            Assert.AreEqual(_copyPage.projectedBalCalcHeading, _ksRetCalcPage.GetProjectedBalanceCalcHeading());
            Assert.IsTrue(_ksRetCalcPage.IsProjectedBalanceDisplayed());
        }

    }

    

}
