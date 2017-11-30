namespace ManageYourBudget.BusinessLogicLayer.Settings
{
    public static class GoogleSettings
    {
        public static string GoogleClientId => System.Configuration.ConfigurationManager.AppSettings["GoogleClientId"];
        public static string GoogleClientSecret => System.Configuration.ConfigurationManager.AppSettings["GoogleClientSecret"];
    }
}