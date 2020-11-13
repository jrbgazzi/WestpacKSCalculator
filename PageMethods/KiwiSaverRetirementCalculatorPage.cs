using OpenQA.Selenium;
using System.Collections.Generic;
using Westpac.DataModel;
using Westpac.PageElements;

namespace Westpac.PageMethods
{
    public class KiwiSaverRetirementCalculatorPage : BasePage
    {
        private IWebDriver _driver;
        private ContextObject _contextObject;
        private KiwiSaverRetirementCalculatorPageElements _ksRetCalcPage;

        public KiwiSaverRetirementCalculatorPage(IWebDriver driver, ContextObject contextObject) : base(driver)
        {
            _driver = driver;
            _contextObject = contextObject;
            _ksRetCalcPage = new KiwiSaverRetirementCalculatorPageElements();
        }

        //gets current window url
        public string GetCurrentUrl()
        {
            return _driver.Url;
        }

        //switch to calculator iframe once available
        public void SwitchToCalculatorIframe()
        {
            WaitForPageToLoad();
            WaitUntilElementNotFound(_ksRetCalcPage.widgetLoadingMask, 1);
            _driver.SwitchTo().Frame(GetElement(_ksRetCalcPage.mainId).FindElement(By.CssSelector("iframe")));
        }

        //click information icon for given parameter
        public void ClickInformationIcon(string element)
        {
            if (element == "Salary" || element == "KiwiSaver member contribution")
            {
                ClickDropdown(GetElements(_ksRetCalcPage.dropdown), "employment");

                var employmentOptions = GetElement(_ksRetCalcPage.employmentStatusSection).FindElement(_ksRetCalcPage.dropDownList).FindElements(By.CssSelector("li"));
                foreach (var item in employmentOptions)
                {
                    if (item.Text == "Employed")
                    {
                        item.Click();
                    }
                }
            }

            var section = GetCalculatorSection(element);

            section.FindElement(By.CssSelector("button")).Click();
        }

        //get information icon text for given parameter
        public string GetInformationIconText(string element)
        {
            var section = GetCalculatorSection(element);
            if (element == "Risk profile")
            {
                var paragraphs = section.FindElements(By.CssSelector("p"));
                var list = section.FindElement(By.CssSelector("ul"));
                return paragraphs[0].Text + list.Text.Replace("\r\n", "") + paragraphs[1].Text;
            }

            return section.FindElement(By.CssSelector("p")).Text;
        }

        //fill up calculator with details from json user profile
        public void FillUpCalculatorWithUserProfile(string persona)
        {
            _contextObject.CurrentUser = GetUserProfile(persona);

            SendKeys(GetElement(_ksRetCalcPage.currentAgeSection).FindElement(By.CssSelector("input")), _contextObject.CurrentUser.CurrentAge);
            ClickDropdown(GetElements(_ksRetCalcPage.dropdown), "employment");

            var employmentOptions = GetElement(_ksRetCalcPage.employmentStatusSection).FindElement(_ksRetCalcPage.dropDownList).FindElements(By.CssSelector("li"));

            foreach (var item in employmentOptions)
            {
                if (item.Text == _contextObject.CurrentUser.EmploymentStatus)
                {
                    item.Click();
                }
            }

            if (_contextObject.CurrentUser.EmploymentStatus == "Employed")
            {
                SendKeys(GetElement(_ksRetCalcPage.salarySection).FindElement(By.CssSelector("input")), _contextObject.CurrentUser.Salary);

                var ksMemContribOptions = GetElement(_ksRetCalcPage.ksMemContribSection).FindElements(By.CssSelector("label"));

                foreach (var item in ksMemContribOptions)
                {
                    if (item.Text == _contextObject.CurrentUser.KiwiSaverMemberContribution)
                    {
                        item.Click();
                    }
                }
            }

            if (_contextObject.CurrentUser.CurrentKiwiSaverBalance != "")
            {
                SendKeys(GetElement(_ksRetCalcPage.currentKsBalanceSection).FindElement(By.CssSelector("input")), _contextObject.CurrentUser.CurrentKiwiSaverBalance);
            }

            if (_contextObject.CurrentUser.VoluntaryContributions != "")
            {

                SendKeys(GetElement(_ksRetCalcPage.voluntaryContribSection).FindElement(By.CssSelector("input")), _contextObject.CurrentUser.VoluntaryContributions);
                ClickDropdown(GetElements(_ksRetCalcPage.dropdown), "volCon");

                var frequencyOptions = GetElement(_ksRetCalcPage.voluntaryContribSection).FindElement(_ksRetCalcPage.dropDownList).FindElements(By.CssSelector("li"));

                foreach (var item in frequencyOptions)
                {
                    if (item.Text == _contextObject.CurrentUser.Frequency)
                    {
                        item.Click();
                    }
                }
            }

            var riskProfileOptions = GetElement(_ksRetCalcPage.riskProfileSection).FindElements(By.CssSelector("label"));

            foreach (var item in riskProfileOptions)
            {
                if (item.Text == _contextObject.CurrentUser.RiskProfile)
                {
                    item.Click();
                }
            }

            if (_contextObject.CurrentUser.SavingsGoalAtRetirement != "")
            {
                SendKeys(GetElement(_ksRetCalcPage.savingsGoalSection).FindElement(By.CssSelector("input")), _contextObject.CurrentUser.SavingsGoalAtRetirement);
            }
        }

        //fill up calculator with given parameters
        public void PopulateField(string entry, string field)
        {
            switch (field)
            {
                case "Current age":
                    SendKeys(GetElement(_ksRetCalcPage.currentAgeSection).FindElement(By.CssSelector("input")), entry);
                    break;

                case "Employment status":
                    ClickDropdown(GetElements(_ksRetCalcPage.dropdown), "employment");

                    var employmentOptions = GetElement(_ksRetCalcPage.employmentStatusSection).FindElement(_ksRetCalcPage.dropDownList).FindElements(By.CssSelector("li"));

                    foreach (var item in employmentOptions)
                    {
                        if (item.Text == entry)
                        {
                            item.Click();
                        }
                    }
                    break;

                case "Salary":
                    if (entry != "")
                    {
                        SendKeys(GetElement(_ksRetCalcPage.salarySection).FindElement(By.CssSelector("input")), entry);
                    }

                    break;

                case "KiwiSaver member contribution":
                    if (entry != "")
                    {
                        var ksMemContribOptions = GetElement(_ksRetCalcPage.ksMemContribSection).FindElements(By.CssSelector("label"));

                        foreach (var item in ksMemContribOptions)
                        {
                            if (item.Text == entry)
                            {
                                item.Click();
                            }
                        }
                    }

                    break;

                case "Current KiwiSaver balance":
                    if (entry != "")
                    {
                        SendKeys(GetElement(_ksRetCalcPage.currentKsBalanceSection).FindElement(By.CssSelector("input")), entry);
                    }

                    break;

                case "Voluntary contributions":
                    if (entry != "")
                    {
                        SendKeys(GetElement(_ksRetCalcPage.voluntaryContribSection).FindElement(By.CssSelector("input")), entry);
                    }

                    break;

                case "Frequency":
                    if (entry != "")
                    {
                        ClickDropdown(GetElements(_ksRetCalcPage.dropdown), "volCon");

                        var frequencyOptions = GetElement(_ksRetCalcPage.voluntaryContribSection).FindElement(_ksRetCalcPage.dropDownList).FindElements(By.CssSelector("li"));

                        foreach (var item in frequencyOptions)
                        {
                            if (item.Text == entry)
                            {
                                item.Click();
                            }
                        }
                    }

                    break;

                case "Risk profile":
                    var riskProfileOptions = GetElement(_ksRetCalcPage.riskProfileSection).FindElements(By.CssSelector("label"));

                    foreach (var item in riskProfileOptions)
                    {
                        if (item.Text == entry)
                        {
                            item.Click();
                        }
                    }

                    break;

                case "Savings goal at retirement":
                    if (entry != "")
                    {
                        SendKeys(GetElement(_ksRetCalcPage.savingsGoalSection).FindElement(By.CssSelector("input")), entry);
                    }
                    break;

            }
        }

        //get label of projected balance button
        public string GetProjectedBalanceButtonLabel()
        {
            var buttonLabels = GetElement(_ksRetCalcPage.projection).FindElement(By.CssSelector("button")).FindElements(By.CssSelector("span"));
            string activeLabel = "";

            foreach (var item in buttonLabels)
            {
                if (item.GetAttribute("class") == "label")
                {
                    activeLabel = item.Text;
                }
            }

            return activeLabel;
        }

        //click dropdown of given parameter
        public void ClickDropdown(IList<IWebElement> dropdown, string type)
        {
            switch (type)
            {
                case "employment":
                    foreach (var item in dropdown)
                    {
                        if (item.Text == "Select")
                        {
                            item.Click();
                        }
                    }
                    break;

                case "volCon":
                    foreach (var item in dropdown)
                    {
                        if (item.Text == "Frequency")
                        {
                            item.Click();
                        }
                    }
                    break;
            }
        }

        //click on projected balance button
        public void ClickProjectedBalanceBtn()
        {
            ClickElement(GetElement(_ksRetCalcPage.projection).FindElement(By.CssSelector("button")));
        }

        //get projected balance calculator heading text
        public string GetProjectedBalanceCalcHeading()
        {
            ClickProjectedBalanceBtn();
            return GetText(GetElement(_ksRetCalcPage.ksHeading));
        }

        //get bool result if projected balance is displayed
        public bool IsProjectedBalanceDisplayed()
        {
            bool result = false;

            if (IsElementDisplayed(GetElement(_ksRetCalcPage.calculatorPanel)) && IsElementDisplayed(GetElement(_ksRetCalcPage.ksBalEstimate)) && IsElementDisplayed(GetElement(_ksRetCalcPage.ksGraph)))
            {
                result = true;
            }

            return result;
        }

        //determines the calculator section from given parameter
        public IWebElement GetCalculatorSection(string element)
        {
            IWebElement section = null;

            switch (element)
            {
                case "Current age":
                    section = GetElement(_ksRetCalcPage.currentAgeSection);
                    break;

                case "Employment status":
                    section = GetElement(_ksRetCalcPage.employmentStatusSection);
                    break;

                case "Salary":
                    section = GetElement(_ksRetCalcPage.salarySection);
                    break;

                case "KiwiSaver member contribution":
                    section = GetElement(_ksRetCalcPage.ksMemContribSection);
                    break;

                case "Current KiwiSaver balance":
                    section = GetElement(_ksRetCalcPage.currentKsBalanceSection);
                    break;

                case "Voluntary contributions":
                    section = GetElement(_ksRetCalcPage.voluntaryContribSection);
                    break;

                case "Risk profile":
                    section = GetElement(_ksRetCalcPage.riskProfileSection);
                    break;

                case "Savings goal at retirement":
                    section = GetElement(_ksRetCalcPage.savingsGoalSection);
                    break;
            }

            return section;
        }

        //sets current user details
        public UserProfile GetUserProfile(string persona)
        {
            _contextObject.CurrentUser = new UserProfile();

            foreach (var item in _contextObject.UserProfiles)
            {
                if (item.Persona == persona)
                {
                    _contextObject.CurrentUser.CurrentAge = item.CurrentAge;
                    _contextObject.CurrentUser.EmploymentStatus = item.EmploymentStatus;
                    _contextObject.CurrentUser.Salary = item.Salary;
                    _contextObject.CurrentUser.KiwiSaverMemberContribution = item.KiwiSaverMemberContribution;
                    _contextObject.CurrentUser.CurrentKiwiSaverBalance = item.CurrentKiwiSaverBalance;
                    _contextObject.CurrentUser.VoluntaryContributions = item.VoluntaryContributions;
                    _contextObject.CurrentUser.Frequency = item.Frequency;
                    _contextObject.CurrentUser.RiskProfile = item.RiskProfile;
                    _contextObject.CurrentUser.SavingsGoalAtRetirement = item.SavingsGoalAtRetirement;
                }
            }

            return _contextObject.CurrentUser;
        }

    }
}
