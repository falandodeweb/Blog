using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falando_de_web.Controllers
{
    public class SobreController : MasterController
    {
        private void Carregar()
        {
            cTexto cTxt = new cTexto();
            cUsuario cUsu = new cUsuario();

            string t = "O projeto", s = "Web é o que fazemos";
            ViewBag.Texto = cTxt.RetornarTexto(1);

            ViewBag.Autor = cUsu.RetornarListaUsuario();

            ViewBag.Master.Header.Titulo = t;
            ViewBag.Master.Header.Subtitulo = s;
            ViewBag.Master.Header.Wallpaper = "Sobre";

            ViewBag.Master.SEO.Title = t;
            ViewBag.Master.SEO.Description = s;
        }

        public ActionResult Index()
        {
            Carregar();
            return View();
        }
    }
}
