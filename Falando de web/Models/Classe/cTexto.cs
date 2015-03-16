using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Falando_de_web.Models.Entidade;

public class cTexto
{
    private Conexao con = new Conexao();

    public string RetornarTexto(int codigo)
    {
        return con.Texto
               .Where(i => i.Codigo == codigo)
               .Select(i => i.Conteudo)
               .First();
    }
}