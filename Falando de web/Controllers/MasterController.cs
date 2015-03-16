using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falando_de_web.Controllers
{
    public class MasterController : Controller
    {
        private void Carregar()
        {
            ViewBag.Master = new
            {
                SEO = new
                {
                    Title = "Falando de Web • Aprenda com quem fala de web e faz parte dela",
                    Description = "Blog aberto à comunidade de desenvolvedores e entusiastas do universo web. Ensinar e aprender num portal com conteúdo grátis e 100% colaborativo",
                    Keywords = string.Empty
                }.ToExpando(),
                Header = new
                {
                    Titulo = "Falando de W3b",
                    Subtitulo = "Aprenda com quem fala de web e faz parte dela",
                    Wallpaper = "Home"
                }.ToExpando()
            }.ToExpando();
        }
        
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Carregar();
        }
    }
}