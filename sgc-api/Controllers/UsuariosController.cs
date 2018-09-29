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
        private FireBaseContext context;

        private IConfiguration _configuration;
        
        public UsuariosController(IConfiguration Configuration)
        {
            _configuration = Configuration;
            context = new FireBaseContext(Configuration);
            
        }
        
        // GET api/usuarios
        [HttpGet]
        public ActionResult Get()
        {
            List<Usuario> listaUsuarios = context.GetUsuarios();

            return Content(JsonConvert.SerializeObject(listaUsuarios));
        }

        [HttpPost("Autenticar")]
        public ActionResult Autenticar([FromBody]Usuario usuario)
        {
            List<Usuario> listaUsuarios = context.GetUsuarios();
            
            Usuario usuarioAutenticado = listaUsuarios.FirstOrDefault<Usuario>(x => x.CPF.Equals(usuario.CPF) && x.Senha.Equals(usuario.Senha));

            return Content(JsonConvert.SerializeObject(usuarioAutenticado));
        }
    }
}
