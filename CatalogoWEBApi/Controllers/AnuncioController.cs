using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatalogoWEBApi.Models;

namespace CatalogoWEBApi.Controllers
{
    [RoutePrefix("api/anuncio")]
    public class AnuncioController : ApiController
    {
            private static List<Anuncio> listaAnuncios = new List<Anuncio>();

            [AcceptVerbs("POST")]
            [Route("CadastrarAnuncio")]
            public string CadastrarAnuncio(Anuncio anuncio)
            {

                listaAnuncios.Add(anuncio);

                return "Anuncio cadastrada com sucesso!";
            }

            [AcceptVerbs("PUT")]
            [Route("AlterarAnuncio")]
            public string AlterarAnuncio(Anuncio anuncio)
            {

                listaAnuncios.Where(n => n.AnuncioId == anuncio.AnuncioId)
                             .Select(s =>
                             {
                                 s.AnuncioId = anuncio.AnuncioId;
                                 s.CategoriaId = anuncio.CategoriaId;
                                 s.ClienteId = anuncio.ClienteId;
                                 s.Descricao = anuncio.Descricao;
                                 s.Imagem = anuncio.Imagem;

                                 return s;

                             }).ToList();

                return "Anuncio alterado com sucesso!";
            }

            [AcceptVerbs("DELETE")]
            [Route("ExcluirAnuncio/{id}")]
            public string ExcluirAnuncio(int id)
            {
                listaAnuncios.Remove(listaAnuncios.FirstOrDefault(a => a.AnuncioId == id));

                return "Registro excluido com sucesso!";
            }

            [AcceptVerbs("GET")]
            [Route("ConsultarAnuncioPorCodigo/{id}")]
            public Anuncio ConsultarAnuncioPorCodigo(int id)
            {
                return listaAnuncios.FirstOrDefault(a => a.AnuncioId == id);
            }

            [AcceptVerbs("GET")]
            [Route("ConsultarAnuncios")]
            public List<Anuncio> ConsultarAnuncios()
            {
                return listaAnuncios;
            }

        }
    }
