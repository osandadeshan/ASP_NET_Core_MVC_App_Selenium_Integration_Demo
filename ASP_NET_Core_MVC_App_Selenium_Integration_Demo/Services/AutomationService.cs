using System;
using ASP_NET_Core_MVC_App_Selenium_Integration_Demo.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ASP_NET_Core_MVC_App_Selenium_Integration_Demo.Services
{
    public static class AutomationService
    {
        public static void RunAutomation(AutomationModel automationModel)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            IWebDriver driver = new ChromeDriver(chromeOptions);

            try
            {
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
                driver.Navigate().GoToUrl(automationModel.Url);

                driver.FindElement(By.Id("email")).SendKeys(automationModel.Email);
                driver.FindElement(By.Id("passwd")).SendKeys(automationModel.Password);
                driver.FindElement(By.Id("SubmitLogin")).Click();
                new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(webDriver => ((IJavaScriptExecutor) webDriver)
                    .ExecuteScript("return document.readyState").Equals("complete"));

                automationModel.Status = driver.Title.Equals(automationModel.HomePageTitle) ? "Completed" : "Failed";
            }
            catch (Exception)
            {
                automationModel.Status = "Failed";
            }

            driver.Quit();
        }
    }
}