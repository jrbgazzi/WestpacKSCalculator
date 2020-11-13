using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westpac.DataModel
{
    public class UserProfile
    {
        public string Persona { get; set; }
        public string CurrentAge { get; set; }
        public string EmploymentStatus { get; set; }
        public string Salary { get; set; }
        public string KiwiSaverMemberContribution { get; set; }
        public string CurrentKiwiSaverBalance { get; set; }
        public string VoluntaryContributions { get; set; }
        public string Frequency { get; set; }
        public string RiskProfile { get; set; }
        public string SavingsGoalAtRetirement { get; set; }
    }
}