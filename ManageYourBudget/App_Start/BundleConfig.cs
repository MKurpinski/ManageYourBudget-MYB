using System.Web.Optimization;

namespace ManageYourBudget
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js", "~/Scripts/datepickerConfig.js", "~/Scripts/jquery-ui-1.12.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/datatableConfig.js"));
            bundles.Add(new ScriptBundle("~/bundles/category").Include(
                "~/Scripts/addCategory.js",
                "~/Scripts/editCategory.js"));
        }
    }
}
