using BoDi;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using Westpac.DataModel;
using Westpac.Steps;

namespace Westpac.Hooks
{

    [Binding]
    public class Hooks : BaseSteps
    {
        protected ScenarioContext ScenarioContext;
        protected IObjectContainer Container;
        protected DateTime TestStartTime;

        public Hooks(ContextObject contextObject, IObjectContainer container) : base(contextObject)
        {
            Container = container;
            ScenarioContext = Container.Resolve<ScenarioContext>();
        }

        [BeforeScenario]
        //setup all needed values before every scenario is ran
        public void SetUp()
        {
            InitConfigAppValues();
            InitTestRun();
            InitDriver();
        }

        [AfterScenario]
        //take screenshots of the test run and saves it to desired repo, cleans up driver after each scenario run
        public void CleanUp()
        {
            try
            {
                string testScenario = ScenarioContext.ScenarioInfo.Title;
                string testScenarioDetails = testScenario + "_" + TestStartTime.ToString("yyyy-MM-dd-HH_mm_ss") + ".jpg";

                try
                {
                    ((ITakesScreenshot)ContextObject.Driver).GetScreenshot().SaveAsFile(ContextObject.ScreenshotRepo + testScenarioDetails, ScreenshotImageFormat.Png);
                }
                catch (Exception ex)
                {
                    TestContext.WriteLine($"Exception: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                ContextObject.Driver.Quit();
            }

        }

        //initialize browser driver, either locally or through grid
        public void InitDriver()
        {
            if (ContextObject.RunOnGrid.Equals("True"))
            {
                //Insert grid config here
            }
            else
            {
                switch (ContextObject.Browser)
                {
                    case "Chrome":
                        ContextObject.Driver = new ChromeDriver();
                        break;

                    case "IE":
                        ContextObject.Driver = new ChromeDriver();
                        break;

                    default:
                        ContextObject.Driver = new ChromeDriver();
                        break;
                }

                ContextObject.Driver.Manage().Window.Maximize();
                ContextObject.Driver.Navigate().GoToUrl(ContextObject.Url);
            }
        }

        //initialize context object variables based from app.config values
        public void InitConfigAppValues()
        {
            ContextObject.Environment = ConfigurationManager.AppSettings["Environment"];
            ContextObject.Browser = ConfigurationManager.AppSettings["Browser"];
            ContextObject.RunOnGrid = ConfigurationManager.AppSettings["RunOnGrid"];
            ContextObject.GridServer = ConfigurationManager.AppSettings["GridServer"];
            ContextObject.ScreenshotRepo = ConfigurationManager.AppSettings["ScreenshotRepo"];
        }

        //sets the url environment, scenarios to run accdg. to tag, gets user profiles from json file, and creates the repo for the screenshots
        public void InitTestRun()
        {
            var testEnvironment = ContextObject.Environment;
            var tags = this.ScenarioContext.ScenarioInfo.Tags.Select(x => x.ToLowerInvariant());
            var tagCollection = tags as string[] ?? tags.ToArray();

            switch (testEnvironment)
            {
                case "dev":
                    if (!tagCollection.Contains("dev"))
                        Assert.Ignore();

                    ContextObject.Url = ConfigurationManager.AppSettings["DevUrl"];
                    break;
                case "qa":
                    if (!tagCollection.Contains("qa"))
                        Assert.Ignore();

                    ContextObject.Url = ConfigurationManager.AppSettings["QaUrl"];
                    break;
                case "prod":
                    if (!tagCollection.Contains("prod"))
                        Assert.Ignore();

                    ContextObject.Url = ConfigurationManager.AppSettings["ProdUrl"];
                    break;
            }

            ContextObject.UserProfiles = JsonConvert.DeserializeObject<List<UserProfile>>(File.ReadAllText($"{TestContext.CurrentContext.TestDirectory}\\UserProfiles.json"),
                new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeNonAscii });

            Directory.CreateDirectory(ContextObject.ScreenshotRepo);
            TestStartTime = DateTime.Now;
        }

    }


}
