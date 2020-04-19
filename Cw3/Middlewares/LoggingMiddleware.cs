using Cw3.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IStudentDbService service)
        {
            if (httpContext.Request != null)
            {
                string sciezka = httpContext.Request.Path;//2
                string querystring = httpContext.Request?.QueryString.ToString();//4
                string metoda = httpContext.Request.Method.ToString();//1
                string bodyStr = "";//3

                using (StreamReader reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    bodyStr = await reader.ReadToEndAsync();
                    //httpContext.Request.Body.Position = 0;
                }
                //zapisat w file
                //logowanie do pliku using
                using (StreamWriter file = new StreamWriter(Directory.GetCurrentDirectory()+"/Log.txt", true))
                {
                    file.WriteLine("HTTP: "+metoda);
                    file.WriteLine("Route: "+sciezka);
                    file.WriteLine("Body: "+bodyStr);
                    file.WriteLine("Query: "+querystring);
                    file.WriteLine("____________________________");
                }

            }
            if(_next != null)
            await _next(httpContext);
        }
    }
}
