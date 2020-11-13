using OpenQA.Selenium;

namespace Westpac.PageElements
{
    class KiwiSaverRetirementCalculatorPageElements
    {
        public KiwiSaverRetirementCalculatorPageElements()
        {

        }

        public By mainId = By.Id("calculator-embed");
        public By widgetLoadingMask = By.XPath("//div[@id='widget-loading-mask']");

        public By currentAgeSection = By.XPath("//div[@help-id='CurrentAge']");
        public By employmentStatusSection = By.XPath("//div[@help-id='EmploymentStatus']");
        public By salarySection = By.XPath("//div[@help-id='AnnualIncome']");
        public By ksMemContribSection = By.XPath("//div[@help-id='KiwiSaverMemberContribution']");
        public By currentKsBalanceSection = By.XPath("//div[@help-id='KiwiSaverBalance']");
        public By voluntaryContribSection = By.XPath("//div[@help-id='VoluntaryContributions']");
        public By riskProfileSection = By.XPath("//div[@help-id='RiskProfile']");
        public By savingsGoalSection = By.XPath("//div[@help-id='SavingsGoal']");

        public By dropdown = By.XPath("//div[@class='control select-control  no-selection']");
        public By dropDownList = By.XPath("//div[(@class='dropdown')]");
        public By projection = By.XPath("//div[@ng-hide='ctrl.view.resultsPanelRevealed']");
        public By calculatorPanel = By.XPath("//div[@ng-show='ctrl.view.resultsPanelRevealed']");
        public By ksHeading = By.XPath("//span[@class='result-title ng-binding']");
        public By ksBalEstimate = By.XPath("//span[@class='result-value result-currency ng-binding']");
        public By ksGraph = By.XPath("//div[@class='results-graph']");
    }
}
