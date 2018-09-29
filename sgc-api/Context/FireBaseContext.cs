using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using sgc_api.Model;
using Microsoft.Extensions.Configuration;

namespace sgc_api.Context
{
    public class FireBaseContext
{
        //Objeto de conexão do banco de dados Firebase usando o midleware FireSharp
        private static FirebaseClient _client;
        //Objeto de Configuração para recuperar as configuração de conexão com o banco
        private IConfiguration _configuration;

        //Construtor da class de contexto do banco de dados
        public FireBaseContext(IConfiguration Configuration)
        {
            //Configuração do banco de dados Firebase
            FirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = Configuration.GetValue<string>("firebase:authSecret"),
                BasePath = Configuration.GetValue<string>("firebase:basePath")
            };

            //Autenticando no banco de dados e conectando no banco de dados
            _client = new FirebaseClient(config);
        }

        //Metodo para retornar todos os usuários cadastrados no banco de dados
        public List<Usuario> GetUsuarios()
        {
            //Conectando no banco e solicitando todos objetos da 'tabela' Usuarios
            FirebaseResponse response = _client.Get("Usuarios");

            //Convertendo a resposta do banco para uma lista de objetos do tipo Usuario
            return response.ResultAs<List<Usuario>>();
        }
}
}
