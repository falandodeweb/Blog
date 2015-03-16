using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Falando_de_web.Models.Entidade;

namespace Falando_de_web.Controllers
{
    public class HomeController : MasterController
    {
        cBlog cBlo = new cBlog();

        private void Titulo(string t, string s)
        {
            if (!string.IsNullOrWhiteSpace(t))
            {
                ViewBag.Master.Header.Titulo = t;
                ViewBag.Master.Header.Subtitulo = s;
                ViewBag.Master.Header.Wallpaper = "Busca";

                ViewBag.Master.SEO.Title = t;
                ViewBag.Master.SEO.Description = s;
            }
        }
        
        private List<Post> RetornarTipoLista(int categoria, int autor)
        {
            List<Post> lista;
            string t = string.Empty, s = "Veja abaixo os posts ";
            
            if (categoria == 0 && autor == 0)
                lista = cBlo.RetornarListaPost();
            else if (categoria > 0)
            {
                lista = cBlo.RetornarListaPostCategoria(categoria);

                t = lista[0].Categoria1.Titulo;
                s = s + "desta categoria";
            }
            else
            {
                lista = cBlo.RetornarListaPostAutor(autor);

                t = lista[0].Usuario1.Nome;
                s = s + "deste autor";
            }

            Titulo(t, s);

            return lista;
        }
        
        public ActionResult Index(string categoria, string autor, int? page)
        {
            var lista = RetornarTipoLista(Convert.ToInt32(categoria), Convert.ToInt32(autor));
            ViewBag.Lista = lista.ToPagedList(page ?? 0, 7);

            return View();
        }
    }
}