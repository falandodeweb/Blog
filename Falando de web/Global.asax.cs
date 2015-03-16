using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Falando_de_web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            string css = "~/content/layout/css/";
            string js = "~/content/scripts/";

            bundles.Add(new StyleBundle("~/css").Include(
                js + "Prettify/prettify.css",
                js + "tooltipster/tooltipster.css",
                js + "tooltipster/tooltipster-light.css",
                js + "lightbox/lightbox.css",
                css + "Blog.css"
            ));

            bundles.Add(new ScriptBundle("~/js").Include(
                js + "Prettify/prettify.js",
                js + "fastclick.js",
                js + "tooltipster/jquery.tooltipster.js",
                js + "lightbox/lightbox.js",
                js + "Blog.js"
            ));
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("robots.txt");
            routes.IgnoreRoute("apple-touch-icon-precomposed.png");
            routes.IgnoreRoute("apple-touch-icon.png");

            routes.MapRoute("Post", "post/{codigo}/{titulo}", new { controller = "Post", action = "Index" });
            routes.MapRoute("Contato", "contato", new { controller = "Contato", action = "Contato" });
            routes.MapRoute("Junte-se", "junte-se", new { controller = "Contato", action = "JunteSe" });
            routes.MapRoute("Sobre", "sobre", new { controller = "Sobre", action = "Index" });
            routes.MapRoute("Paginação autor", "autor/{autor}/{titulo}/pagina/{page}", new { controller = "Home", action = "Index" });
            routes.MapRoute("Autor", "autor/{autor}/{titulo}", new { controller = "Home", action = "Index" });
            routes.MapRoute("Paginação categoria", "categoria/{categoria}/{titulo}/pagina/{page}", new { controller = "Home", action = "Index" });
            routes.MapRoute("Categoria", "categoria/{categoria}/{titulo}", new { controller = "Home", action = "Index" });
            routes.MapRoute("Paginação home", "pagina/{page}", new { controller = "Home", action = "Index" });
            routes.MapRoute("Erro", "=(", new { controller = "Erro", action = "Index" });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();
            cSistema.InserirErro(exc.Message, exc.InnerException != null ? exc.InnerException.Message : null);
            Response.Redirect("~/=(", true);
        }
    }
}