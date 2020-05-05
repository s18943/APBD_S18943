using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cw3.Handlers;
using Cw3.Middlewares;
using Cw3.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Cw3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidIssuer = "Gakko",
                           ValidAudience = "Students",
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]))
                       };
                   });

            //services.AddAuthentication("AuthenticationBasic")
            //      .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("AuthenticationBasic", null);

            services.AddTransient<IStudentDbService, SqlServerStudentDbService>();
            services.AddControllers()
                .AddXmlSerializerFormatters();
            //services.AddSwaggerGen(config =>
            //{
            //    config.SwaggerDoc("v1", new OpenApiInfo { Title = "Students App Api", Version = "1v" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStudentDbService service)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseMiddleware<ExceptionMiddleware>();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();
            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //// specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(config =>
            //{
            //    config.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});

            //Globalna obs³uga b³êdów
            //app.UseExceptionHandler(options =>
            //{
            //    options.Run(
            //    async context =>
            //    {
            //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //        context.Response.ContentType = "application/json";

            //        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            //        if (contextFeature != null)
            //        {
            //            await context.Response.WriteAsync(new ErrorDetails()
            //            {
            //                StatusCode = context.Response.StatusCode,
            //                Message = "Internal Server Error."
            //            }.ToString());
            //        }
            //    });
            //});

            //app.UseMiddleware<LoggingMiddleware>();
            //app.UseWhen(context => context.Request.Path.ToString().Contains("secret"), app =>
            //{
            //    app.Use(async (context, next) =>
            //    {
            //        if (!context.Request.Headers.ContainsKey("Index"))
            //        {
            //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //            await context.Response.WriteAsync("Musisz podacz numer indeksu");
            //            return;
            //        }

            //        string index = context.Request.Headers["Index"].ToString();
            //        //check in db
            //        var stud = service.GetStudent(index);
            //        if(stud == null)
            //        {
            //            context.Response.StatusCode = StatusCodes.Status404NotFound;
            //            await context.Response.WriteAsync("Student not found");
            //            return;
            //        }

            //    await next();
            //    });

            //});

            //app.UseMiddleware<LoginMiddleware>();

            //app.Use(async (context, next) =>
            //{
            //    if (!context.Request.Headers.ContainsKey("Index")) 
            //    {
            //        context.Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized;
            //        await context.Response.WriteAsync("Nie poda³eœ loginu i has³a");
            //        return;

            //    }
            //    else
            //    {
            //        string index = context.Response.Headers["Index"].ToString();
            //        //string index = context.Response.Headers["Index"].ToString();
            //        //...
            //        // new SqlConnection();
            //    }



            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
