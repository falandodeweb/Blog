using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Falando_de_web.Models.Entidade;

public class cUsuario
{
    private Conexao con = new Conexao();

    public List<Usuario> RetornarListaUsuario()
    {
        return con.Usuario
               .Where(i => i.Ativo)
               .ToList();
    }
}