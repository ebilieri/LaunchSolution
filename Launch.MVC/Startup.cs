using Launch.Domain.Contratos.IRepositorio;
using Launch.Domain.Contratos.IServices;
using Launch.Domain.Services;
using Launch.Repository.Contexto;
using Launch.Repository.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Launch.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("config.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // String de conexão com o Banco de dados (MySql)
            var connectionString = Configuration.GetConnectionString("LaunchConnection");

            services.AddDbContext<LaunchContexto>(option =>
                    option.UseLazyLoadingProxies()
                        .UseSqlServer(connectionString, m =>
                            m.MigrationsAssembly("Launch.Repository")));


            // Mapeamento Injeção de dependencia Repositorios 
            services.AddScoped<ICandidatoRepositorio, CandidatoRepositorio>();
            services.AddScoped<IVotacaoRepositorio, VotacaoRepositorio>();
            services.AddScoped<IVotacaoDiariaRepositorio, VotacaoDiariaRepositorio>();
            services.AddScoped<IVotacaoSemanalRepositorio, VotacaoSemanalRepositorio>();

            // Mapeamento Injeção de dependencia Services
            services.AddScoped<ICandidatoService, CandidatoService>();
            services.AddScoped<IVotacaoService, VotacaoService>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            AutoMapper.Mapper.Initialize((cfg) =>
            {
                cfg.AddProfile<AutoMapperConfig.MappingProfile>();
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
