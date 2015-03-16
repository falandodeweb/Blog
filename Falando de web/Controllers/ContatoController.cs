using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Falando_de_web.Controllers
{
    public class ContatoController : MasterController
    {
        private cTexto cTxt = new cTexto();
        
        private void Carregar(int tipo)
        {
            string t = "Entre em contato";
            string s = "Temos (algumas) respostas às suas perguntas";
            string w = "Contato";
            int c = 4;

            if (tipo == 2)
            {
                t = "Junte-se a nós!";
                s = "Faça parte desta nobre equipe";
                w = "Junte-se";
                c = 3;
            }

            ViewBag.Master.Header.Titulo = t;
            ViewBag.Master.Header.Subtitulo = s;
            ViewBag.Master.Header.Wallpaper = w;

            ViewBag.Master.SEO.Title = t;
            ViewBag.Master.SEO.Description = s;

            ViewBag.Texto = cTxt.RetornarTexto(c);
        }

        private void Enviar(int tipo)
        {
            if (Request.HttpMethod == "POST" && !string.IsNullOrWhiteSpace("txt_nome"))
            {
                cContato cCon = new cContato();
                string t = tipo == 1 ? "mensagem" : "proposta";

                int p = cCon.InserirContato(tipo,
                                            Request["txt_nome"],
                                            Request["txt_email"],
                                            Request["txt_telefone"],
                                            Request["txt_msg"]);

                string msg = "<p>Sua " + t + " foi enviada com sucesso!";
                msg += " Seu número de protocolo é: <strong>" + p + "</strong>.";
                msg += " Retornaremos dentro em breve.</p>";

                ViewBag.Protocolo = msg;
            }
        }
        
        public ActionResult Contato()
        {
            Carregar(1);
            Enviar(1);
            return View();
        }

        public ActionResult JunteSe()
        {
            Carregar(2);
            Enviar(2);

            return View();
        }
    }
}