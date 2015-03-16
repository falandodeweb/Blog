using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Falando_de_web.Models.Entidade;

public class cBlog
{
    private Conexao con = new Conexao();

    public List<Post> RetornarListaPost()
    {
        var lista = con.Post
               .Where(i => i.DataPublicacao <= DateTime.Now && i.Aprovado);

        return lista.OrderByDescending(i => i.DataPublicacao)
               .ToList();
               
    }

    public List<Post> RetornarListaPostCategoria(int codigo)
    {
        var lista = con.Post
                       .Where(i => i.DataPublicacao <= DateTime.Now && i.Categoria == codigo && i.Aprovado);

        return lista
               .OrderByDescending(i => i.DataPublicacao)
               .ToList();   
    }

    public List<Post> RetornarListaPostAutor(int codigo)
    {
        var lista = con.Post
                       .Where(i => i.DataPublicacao <= DateTime.Now && i.Usuario == codigo && i.Aprovado);
               
        return lista
               .OrderByDescending(i => i.DataPublicacao)
               .ToList();
    }

    public Post RetornarPost(int codigo)
    {
        return con.Post
               .Where(i => i.Codigo == codigo && i.Aprovado)
               .First();
    }
}