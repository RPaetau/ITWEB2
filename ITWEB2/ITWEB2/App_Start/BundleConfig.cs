using System.Web;
using System.Web.Optimization;

namespace ITWEB2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/ProteinCalculatorApp")
                .IncludeDirectory("~/Scripts/app/controllers", "*.js")
                .Include("~/Scripts/app/ProteinCalculatorApp.js"));
        }
    }
}
