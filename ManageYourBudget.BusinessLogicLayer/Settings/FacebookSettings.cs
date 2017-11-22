namespace ManageYourBudget.BusinessLogicLayer.Settings
{
    public static class FacebookSettings
    {
        public static string FacebookAppId => System.Configuration.ConfigurationManager.AppSettings["FacebookAppId"];
        public static string FacebookAppSecret => System.Configuration.ConfigurationManager.AppSettings["FacebookAppSecret"];
        public static string FacebookTokenClaim => System.Configuration.ConfigurationManager.AppSettings["FacebookTokenClaim"];
        public static string FacebookEmailScope => System.Configuration.ConfigurationManager.AppSettings["FacebookEmailScope"];
        public static string FacebookQuery => System.Configuration.ConfigurationManager.AppSettings["FacebookQuery"];
    }
}