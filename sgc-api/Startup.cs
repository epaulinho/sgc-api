using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace sgc_api
{
    public class Startup
    {
        //Construtor da classe
        public Startup(IConfiguration configuration)
        {
            //Configurações da aplicação
            Configuration = configuration;
        }

        //Objeto de configuração
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //Define configuração da aplicação
            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //Verifica ambiente de execução
            if (env.IsDevelopment())
            {
                //Inicia aplicação no modo Desenvolvimento
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Inicia aplicação no demais modos de execução
                app.UseHsts();
            }

            //Configura HTTPS
            app.UseHttpsRedirection();
            //Configura aplicação como MVC
            app.UseMvc();
        }
    }
}
