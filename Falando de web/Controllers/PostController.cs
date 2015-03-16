using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falando_de_web.Controllers
{
    public class PostController : MasterController
    {
        private cBlog cBlo = new cBlog();

        private void Carregar(string codigo)
        {
            var post = cBlo.RetornarPost(Convert.ToInt32(codigo));

            ViewBag.Post = post;
            
            ViewBag.Master.Header.Wallpaper = post.Codigo;
            ViewBag.Master.SEO.Title = post.Titulo;
            ViewBag.Master.SEO.Description = !string.IsNullOrWhiteSpace(post.Subtitulo) ? post.Subtitulo : cUtil.RemoverHtml(post.Texto, 100, true);
            ViewBag.Master.SEO.Keywords = post.Tag;
        }
        
        public ActionResult Index(string codigo)
        {
            Carregar(codigo);
            
            return View();
        }
    }
}