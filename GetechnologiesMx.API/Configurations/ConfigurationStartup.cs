using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using GetechnologiesMx.Service.DataContext;
using GetechnologiesMx.Service.Services.IUnitOfworks;
using GetechnologiesMx.Service.Services.UnitofWorkService;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Configuration;

namespace GetechnologiesMx.API.Configurations
{
    public static class ConfigurationStartup
    {
        /// <summary>
        /// Configuracion de CORS para la api de Gestor de aplicaciones.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection Configurar_Cors(this IServiceCollection services)
        {
            string nameCors = "Cors_Getechno";
            services.AddCors(x =>
            {
                x.DefaultPolicyName = nameCors;
                x.AddPolicy(nameCors, policy =>
                {
                    policy.AllowAnyHeader().AllowAnyHeader().AllowAnyMethod();
                });
            });
            return services;
        }

        /// <summary>
        /// Configuracion de los repositories, Sservices para realizacion de la inyecion de dependencias utilizados en el Gestor de aplicaciones.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection Configurar_Repositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfwork, UnitofWorkService>();
            services.AddTransient<ApiExceptionHandler>();
            services.AddScoped<ApiDbContext>();

            return services;
        }
        //protected override void OnConfiguring(ApiDbContext options)
        //{
        //    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //    options.UseSqlite(Configuration.GetConnectionString("GetechnologiesMxDB"));
        //}

        public static IServiceCollection AddConfigurationDBA(this IServiceCollection services, IConfiguration _config)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApiDbContext>(c => c.UseSqlite(_config.GetConnectionString("GetechnologiesMxDB")));
            ////services.AddDbContext<GestorApli>(c=> c.UseSqlServer(_config.GetConnectionString("DB_Probol")));
            //switch (CurrentEnvironment.EnvironmentName)
            //{
            //    case "IntegrationTesting":
            //        var connection = new SqliteConnection
            //                  ("DataSource=:memory:");
            //        connection.Open();
            //        services.AddDbContext<ApiDbContext>(opt =>
            //                      opt.UseSqlite(connection));

            //        break;
            //}
            return services;
        }

        ////public static IServiceCollection AgregarTokenSwagger(this IServiceCollection services)
        ////{
        ////    services.AddSwaggerGen(opt =>
        ////    {
        ////        opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        ////        {
        ////            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        ////            Description = "PLease Introduce Token",
        ////            Name = "Authorization",
        ////            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        ////            BearerFormat = "JWT",
        ////            Scheme = "Bearer"
        ////        });
        ////        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
        ////            {
        ////                {
        ////                    new OpenApiSecurityScheme
        ////                    {
        ////                        Reference = new OpenApiReference
        ////                        {
        ////                            Type=ReferenceType.SecurityScheme,
        ////                            Id="Bearer"
        ////                        }
        ////                    },
        ////                    new string[]{}
        ////                }
        ////            });
        ////    });
        ////    return services;
        ////}

        public static IApplicationBuilder UseCorrs(this IApplicationBuilder app)
        {
            app.UseCors("AlowAll");
            return app;
        }


    }
}
