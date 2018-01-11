using System.Web;
using System.Web.Optimization;

namespace GoedertWeb.UI
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/lib/jquery-ui.min.js",
                        "~/Scripts/lib/jquery.loading.min.js",
                        "~/Scripts/lib/jquery-ajaxSetup.js",
                        "~/Scripts/lib/bootstrap-datepicker.min.js",
                        "~/Scripts/lib/bootstrap-datepicker.pt-BR.min.js",
                        "~/Scripts/lib/jquery.mask.min.js",
                        "~/Scripts/lib/notify.min.js",
                        "~/Scripts/lib/validator.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/lib/jquery-ui.min.css",
                      "~/Content/lib/jquery.loading.min.css",
                      "~/Content/lib/bootstrap-datepicker.min.css",
                      "~/Content/lib/font-awesome.min.css"));
        }
    }
}
