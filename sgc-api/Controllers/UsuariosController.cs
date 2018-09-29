using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sgc_api.Context;
using sgc_api.Model;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace sgc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //Objeto para conexão com o banco de dados 
        private FireBaseContext context;

        //Objeto de configuração da aplicação
        private IConfiguration _configuration;
        
        //Construtor da classe, recuperando as configurações da aplicação
        public UsuariosController(IConfiguration Configuration)
        {
            //Copiando as configuração da aplicaçào para o objeto da classe
            _configuration = Configuration;
            //Instanciando o objeto do banco de dados
            context = new FireBaseContext(Configuration);
            
        }
        
        //Retorna todos os usuarios da base
        // GET api/usuarios
        [HttpGet]
        public ActionResult Get()
        {
            //Cria lista de usuários
            List<Usuario> listaUsuarios = context.GetUsuarios();

            //Retorna lista de usuários no formato JSON
            return Content(JsonConvert.SerializeObject(listaUsuarios));
        }

        //Autentica usuario apartir do objeto Usuário
        [HttpPost("Autenticar")]
        public ActionResult Autenticar([FromBody]Usuario usuario)
        {
            //Cria lista de usuários
            List<Usuario> listaUsuarios = context.GetUsuarios();

            //Seleciona usuário da lista cujo CPF e SENHA sejam do usuario recebido no metodo da API
            Usuario usuarioAutenticado = listaUsuarios.FirstOrDefault<Usuario>(x => x.CPF.Equals(usuario.CPF) && x.Senha.Equals(usuario.Senha));

            //Retorna usuário encontrado
            return Content(JsonConvert.SerializeObject(usuarioAutenticado));
        }
    }
}
