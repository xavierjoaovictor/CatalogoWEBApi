using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatalogoWEBApi.Models;

namespace CatalogoWEBApi.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {

        private static List<Cliente> listaClientes = new List<Cliente>();

        [AcceptVerbs("POST")]
        [Route("CadastrarCliente")]
        public string CadastrarCliente(Cliente cliente)
        {

            listaClientes.Add(cliente);

            return "Cliente cadastrada com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarCliente")]
        public string AlterarCliente(Cliente cliente)
        {

            listaClientes.Where(n => n.ClienteId == cliente.ClienteId)
                         .Select(s =>
                         {
                             s.ClienteId = cliente.ClienteId;
                             s.Anuncios = cliente.Anuncios;
                             s.Cnpj = cliente.Cnpj;
                             s.DataCadastro = cliente.DataCadastro;
                             s.Email = cliente.Email;
                             s.NomeFantasia = cliente.NomeFantasia;
                             s.RazaoSocial = cliente.RazaoSocial;
                             s.Telefone = cliente.Telefone;
                             s.Senha = cliente.Senha;

                             return s;

                         }).ToList();

            return "Cliente alterado com sucesso!";
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirCliente/{id}")]
        public string ExcluirCliente(int id)
        {
            listaClientes.Remove(listaClientes.FirstOrDefault(a => a.ClienteId == id));

            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarClientePorCodigo/{id}")]
        public Cliente ConsultarClientePorCodigo(int id)
        {
            return listaClientes.FirstOrDefault(a => a.ClienteId == id);
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarClientes")]
        public List<Cliente> ConsultarClientes()
        {
            return listaClientes;
        }
    }
}

