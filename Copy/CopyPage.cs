using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westpac.Copy
{
    public class CopyPage
    {
        //ks calc page url
        public string ksCalcPageUrl = "https://www.westpac.co.nz/kiwisaver/calculators/kiwisaver-calculator/";

        //info icon copies
        public string currentAgeInfoText = "This calculator has an age limit of 18 to 64 years old.";
        public string statusInfoText = "If you are earning a salary or wage, select ‘Employed’. " +
            "Your employer contributions will be automatically calculated at a rate of 3% of your before-tax salary or wages. " +
            "You can also select ‘Self-employed’ or ‘Not employed’ and then enter below (in the Voluntary contributions field), " +
            "the amount and frequency of any contributions that you wish to make.";
        public string salaryinfoText = "Only include your total annual income that is paid to you by your employer(s). " +
            "Other income sources such as rental income or dividends should not be included.";
        public string ksMemConInfoText = "You can choose to contribute a regular amount equal to 3%, 4%, 6%, 8% or 10% of your before-tax " +
            "salary or wage. If you do not select a rate, your rate will be 3%.";
        public string currentKsBalInfoText = "If you do not have a KiwiSaver account, then leave this field blank.";
        public string volConInfoText = "If you are 'Self-Employed' or 'Not employed', you can make direct contributions to your KiwiSaver account. " +
            "If you are 'Employed', you can make voluntary contributions in addition to your regular employee contributions.";
        public string riskProfileInfoText = "The risk profile affects your potential investment returns:" +
            "Low risk investments usually contain mostly income assets. Generally, investments of this nature can be expected to deliver modest but more consistent returns. " +
            "They are less likely to go up and down, but will usually provide lower returns over the long term.Medium risk investments are spread more evenly between income " +
            "assets and growth assets. Generally, these types of investments can be expected to provide moderate levels of returns with moderate levels of investment risk. " +
            "Returns will vary and may be low or negative in some years.High risk investments usually contain mostly growth assets. Investments with more exposure to growth " +
            "assets have the potential for higher long-term returns, but they are more likely to go up and down in the short term and will experience periods of negative returns." +
            "You can also use our KiwiSaver Risk Profiler to help determine your tolerence to risk.";
        public string savingsGoalAtRetInfoText = "Enter the amount you would like to have saved when you reach your intended retirement age. " +
            "If you aren’t sure what this amount is, you can leave it blank or use the Sorted Retirement Planner";

        //calculator element copies
        public string projectedBalBtnLabel = "View your KiwiSaver retirement projections";
        public string projectedBalCalcHeading = "At age 65, your KiwiSaver balance is estimated to be:";

        //gets copy text accdg to given parameter
        public string GetInfoTextCopy(string element)
        {
            string infoTextCopy = "";
            switch (element)
            {
                case "Current age":
                    infoTextCopy = currentAgeInfoText;
                    break;

                case "Employment status":
                    infoTextCopy = statusInfoText;
                    break;

                case "Salary":
                    infoTextCopy = salaryinfoText;
                    break;

                case "KiwiSaver member contribution":
                    infoTextCopy = ksMemConInfoText;
                    break;

                case "Current KiwiSaver balance":
                    infoTextCopy = currentKsBalInfoText;
                    break;

                case "Voluntary contributions":
                    infoTextCopy = volConInfoText;
                    break;

                case "Risk profile":
                    infoTextCopy = riskProfileInfoText;
                    break;

                case "Savings goal at retirement":
                    infoTextCopy = savingsGoalAtRetInfoText;
                    break;
            }

            return infoTextCopy;
        }
        



    }
}
