using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Falando_de_web.Models.Entidade;

public class cContato
{
    private Conexao con = new Conexao();
    private Contato cont = new Contato();

    public int InserirContato(int tipo, string nome, string email, string telefone, string mensagem)
    {
        cont.Tipo = tipo;
        cont.DataCadastro = DateTime.Now;
        cont.Nome = nome;
        cont.Email = email;
        cont.Telefone = telefone;
        cont.Mensagem = mensagem;

        con.Contato.Add(cont);
        con.SaveChanges();

        try
        {
            cEnviarEmail.Enviar(tipo, cont.Codigo, nome, email, telefone, mensagem);
            cont.Enviado = true;
        }
        catch { cont.Enviado = false; }

        con.SaveChanges();

        return cont.Codigo;
    }
}