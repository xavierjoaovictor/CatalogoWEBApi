using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogoWEBApi.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string NomeFantasia { get; set; }

        public DateTime DataCadastro { get; set; }
        
        public string RazaoSocial { get; set; }
        
        public string Cnpj { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public int Telefone { get; set; }
        
        public virtual IEnumerable<Anuncio> Anuncios { get; set; }
    }
}