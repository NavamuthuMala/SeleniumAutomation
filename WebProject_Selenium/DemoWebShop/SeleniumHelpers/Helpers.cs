using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace DemoWebShop.SeleniumHelpers
{
    public class Helpers
    {
        private static WebDriver _driver;
        public void SetupDriver(string url)
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(url);
        }

        public void WaitForAjax(int waitTime = 30) => new WebDriverWait(_driver,
            TimeSpan.FromSeconds(30.0)).Until(
            driver => ((IJavaScriptExecutor)driver).ExecuteScript("return window.jQUery != undefined && jQuery.active == 0"));

        public void WaitForDom(int waitTime = 30)
        {
            WaitForAjax(waitTime);
            IWait<IWebDriver> wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30.0));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until(driver => ((IJavaScriptExecutor)driver)
           .ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void ClickElement(By locator)
        {
            WaitForDom();
            WaitForElementToDisplay(locator, 2);
            _driver.FindElement(locator).Click();
        }

        public void EnterText(By locator, string text)
        {
            WaitForDom();
            _driver.FindElement(locator).Click();
            _driver.FindElement(locator).SendKeys(text);
        }

        public string GetElementText(By locator, int waitTime = 5)
        {
            WaitForDom();
            return _driver.FindElement(locator).Text;
        }

        public bool CheckElementEnabled(By locator)
        {
            try
            {
                return _driver.FindElement(locator).Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool CheckElementEnabled(By locator, int waitTime = 10)
        {
            WaitForDom();
            bool flag1 = true;
            bool flag2 = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < TimeSpan.FromSeconds((double)waitTime) & flag1)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(50.0));
                try
                {
                    flag2 = CheckElementEnabled(locator);
                    flag1 = flag2 ? false : true;
                }
                catch (StaleElementReferenceException)
                {
                    flag1 = true;
                }
            }
            return flag2;
        }

        public void WaitForElementToDisplay(By locator, int waitTime = 10)
        {
            WaitForDom();
            bool flag1 = true;
            bool flag2 = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < TimeSpan.FromSeconds((double)waitTime) & flag1)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(50.0));
                try
                {
                    flag2 = CheckElementDisplayed(locator);
                    flag1 = flag2 ? false : true;
                }
                catch (StaleElementReferenceException)
                {
                    flag1 = true;
                }
            }
        }

        public bool CheckElementDisplayed(By locator, int waitTime = 10)
        {
            WaitForDom();
            bool flag1 = true;
            bool flag2 = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while(stopwatch.Elapsed < TimeSpan.FromSeconds((double) waitTime) & flag1)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(50.0));
                try
                {
                    flag2 = CheckElementDisplayed(locator);
                    flag1 = flag2 ? false : true;
                }
                catch (StaleElementReferenceException)
                {
                    flag1 = true;
                }
            }
            return flag2;
        }

        public bool CheckElementDisplayed(By locator)
        {
            try
            {
                return _driver.FindElement(locator).Displayed;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }

        public void SelectOption(By locator, string option)
        {
            WaitForDom();
            var element = _driver.FindElement(locator);
            element.SendKeys(option);
            element.SendKeys(Keys.Enter);
        }

        public void DisposeDriver()
        {
            _driver.Dispose();
        }
    }
}
