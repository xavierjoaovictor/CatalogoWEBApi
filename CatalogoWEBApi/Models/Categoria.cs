using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogoWEBApi.Models
{
    public class Categoria
    {
        public virtual IEnumerable<Anuncio> Anuncios { get; set; } = new List<Anuncio>();

        public int CategoriaId { get; set; }

        public string Descricao { get; set; }
    }
}