using System.Collections.Generic;

namespace ASP_NET_Core_MVC_App_Selenium_Integration_Demo.Models
{
    public static class Repository
    {
        private static readonly List<AutomationModel> AllSeleniumModels = new List<AutomationModel>();

        public static IEnumerable<AutomationModel> GetSeleniumModels => AllSeleniumModels;

        public static void Create(AutomationModel automationModel)
        {
            AllSeleniumModels.Add(automationModel);
        }
    }
}