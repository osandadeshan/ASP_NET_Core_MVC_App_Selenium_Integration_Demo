using System;
using ASP_NET_Core_MVC_App_Selenium_Integration_Demo.Models;
using ASP_NET_Core_MVC_App_Selenium_Integration_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Core_MVC_App_Selenium_Integration_Demo.Controllers
{
    public class AutomationController : Controller
    {
        // HTTP GET
        public IActionResult Execute()
        {
            return View();
        }

        // HTTP POST
        [HttpPost]
        public IActionResult Execute(AutomationModel automationModel)
        {
            Repository.Create(automationModel);

            Console.WriteLine("Web App Url: " + automationModel.Url);
            Console.WriteLine("Email Address: " + automationModel.Email);
            Console.WriteLine("Password: " + automationModel.Password);
            Console.WriteLine("Expected Home Page Title: " + automationModel.ExpectedHomePageTitle);

            AutomationService.RunAutomation(automationModel);

            return View("Result", automationModel);
        }
    }
}