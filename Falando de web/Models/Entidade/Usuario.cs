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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Log = new HashSet<Log>();
            this.Post = new HashSet<Post>();
        }
    
        public int Codigo { get; set; }
        public System.DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public bool Master { get; set; }
    
        public virtual ICollection<Log> Log { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}