using System.Web;
using System.Web.Optimization;

namespace CSharp_ASPNET_MVC_CRUD_SQL
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bundle for Bootstrap
            /*
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            */

            // Bundle for SemanticUI
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/semantic_js").Include("~/Scripts/semantic.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery_visibility").Include("~/Content/components/visibility.js*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery_sidebar").Include("~/Content/components/sidebar.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery_transition").Include("~/Content/components/transition.js"));

            bundles.Add(new StyleBundle("~/Content/semantic_css").Include("~/Content/semantic.min.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/components/reset.css",
                      "~/Content/components/site.css",
                      "~/Content/components/container.css",
                      "~/Content/components/grid.css",
                      "~/Content/components/header.css",
                      "~/Content/components/image.css",
                      "~/Content/components/menu.css",
                      "~/Content/components/divider.css",
                      "~/Content/components/dropdown.css",
                      "~/Content/components/segment.css",
                      "~/Content/components/button.css",
                      "~/Content/components/list.css",
                      "~/Content/components/icon.css",
                      "~/Content/components/sidebar.css",
                      "~/Content/components/transition.css"
                ));
        }
    }
}
