//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Falando_de_web.Models.Entidade
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contato
    {
        public int Codigo { get; set; }
        public int Tipo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
        public bool Enviado { get; set; }
    }
}
