using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westpac.DataModel
{
    public class ContextObject
    {
        public IWebDriver Driver { get; set; }
        public string Environment { get; set; }
        public string Url { get; set; }
        public string Browser { get; set; }
        public string Repo { get; set; }
        public string RunOnGrid { get; set; }
        public string GridServer { get; set; }
        public string ScreenshotRepo { get; set; }
        public List<UserProfile> UserProfiles { get; set; }
        public UserProfile CurrentUser { get; set; }
    }
}
