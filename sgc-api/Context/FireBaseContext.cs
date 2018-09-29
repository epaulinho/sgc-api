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
        private static FirebaseClient _client;
        private IConfiguration _configuration;

        public FireBaseContext(IConfiguration Configuration)
        {
            FirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = Configuration.GetValue<string>("firebase:authSecret"),
                BasePath = Configuration.GetValue<string>("firebase:basePath")
            };

            _client = new FirebaseClient(config);
        }

        public List<Usuario> GetUsuarios()
        {
            FirebaseResponse response = _client.Get("Usuarios");

            return response.ResultAs<List<Usuario>>();
        }
}
}
