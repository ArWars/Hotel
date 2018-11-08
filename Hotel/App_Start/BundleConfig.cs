using System.Web;
using System.Web.Optimization;

namespace Hoteles
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/globalize*",
                "~/Scripts/moment/moment-with-locales.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/localization/messages_es.js",
                        "~/Scripts/additional-methods.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap*",
                      "~/Scripts/bootstrap/tempusdominus-bootstrap-4.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/hoteles.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap*",
                      "~/Content/bootstrap/tempusdominus-bootstrap-4.min.css",
                      "~/Content/hoteles.css"));
        }
    }
}
