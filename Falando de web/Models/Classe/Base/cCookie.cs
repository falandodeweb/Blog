using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Web.UI;

public class cCookie
{
    public cCookie()
    {

    }

    public static void CriarCookie(string titulo, string valor, bool ativo)
    {
        ExcluirCookie(titulo);

        HttpCookie myCookie = new HttpCookie(titulo);
        myCookie.Value = valor;

        if (ativo)
            myCookie.Expires = DateTime.Now.AddYears(1);

        HttpContext.Current.Response.Cookies.Add(myCookie);
    }

    public static void CriarCookie(string titulo, string valor, DateTime expiracao)
    {
        ExcluirCookie(titulo);

        HttpCookie myCookie = new HttpCookie(titulo);

        myCookie.Value = valor;
        myCookie.Expires = expiracao;

        HttpContext.Current.Response.Cookies.Add(myCookie);
    }

    public static void ExcluirCookie(string titulo)
    {
        if (HttpContext.Current.Request.Cookies[titulo] != null)
        {
            HttpCookie myCookie = new HttpCookie(titulo);
            myCookie.Expires = DateTime.Now.AddYears(-10);
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }
    }

    public static void ExcluirCookie()
    {
        string lista = "_wltAdm,_wltUsuario";

        if (lista.Contains(","))
        {
            string[] cookie = lista.Split(',');

            foreach (var item in cookie)
            {
                if (HttpContext.Current.Request.Cookies[item] != null)
                {
                    var c = new HttpCookie(item);
                    c.Expires = DateTime.Now.AddYears(-10);
                    HttpContext.Current.Response.Cookies.Add(c);
                }
            }
        }
        else
        {
            var c = new HttpCookie(lista);
            c.Expires = DateTime.Now.AddYears(-10);
            HttpContext.Current.Response.Cookies.Add(c);
        }
    }

    public static bool VerificarCookie(string titulo)
    {
        if (HttpContext.Current.Request.Cookies[titulo] != null)
            return true;
        else
            return false;
    }

    public static string RetornarCookie(string titulo)
    {
        return HttpContext.Current.Request.Cookies[titulo].Value;
    }
}