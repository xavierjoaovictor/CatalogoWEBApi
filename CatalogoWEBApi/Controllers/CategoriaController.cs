using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatalogoWEBApi.Models;

namespace CatalogoWEBApi.Controllers
{
    [RoutePrefix("api/categoria")]
    public class CategoriaController : ApiController
    {

        private static List<Categoria> listaCategorias = new List<Categoria>();

        [AcceptVerbs("POST")]
        [Route("CadastrarCategoria")]
        public string CadastrarCategoria(Categoria categoria)
        {

            listaCategorias.Add(categoria);

            return "Categoria cadastrada com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarCategoria")]
        public string AlterarCategoria(Categoria categoria)
        {

            listaCategorias.Where(n => n.CategoriaId == categoria.CategoriaId)
                         .Select(s =>
                         {
                             s.CategoriaId = categoria.CategoriaId;
                             s.Anuncios = categoria.Anuncios;
                             s.Descricao = categoria.Descricao;

                             return s;

                         }).ToList();



            return "Categoria alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirCategoria/{id}")]
        public string ExcluirCategoria(int id)
        {

            var categoria = listaCategorias.Where(n => n.CategoriaId == id)
                                                .Select(n => n)
                                                .First();

            listaCategorias.Remove(categoria);

            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarCategoriaPorCodigo/{id}")]
        public Categoria ConsultarCategoriaPorCodigo(int id)
        {
            return listaCategorias.FirstOrDefault(a => a.CategoriaId == id);
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarCategorias")]
        public List<Categoria> ConsultarCategorias()
        {
            return listaCategorias;
        }
    }
}
