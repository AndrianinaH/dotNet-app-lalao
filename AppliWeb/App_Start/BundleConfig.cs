using System.Web;
using System.Web.Optimization;

namespace AppliWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/Script/js").Include(
                      "~/Scripts/jquery-3.1.1.min.js",
                      "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/materialize.min.js",
                      "~/Scripts/user.js",
                      "~/Scripts/utile.js",
                      "~/Scripts/moment-with-locales.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/application.css",
                      "~/Content/jquery.dataTables.css",
                      "~/Content/materialize.min.css"
                      ));
        }
    }
}
