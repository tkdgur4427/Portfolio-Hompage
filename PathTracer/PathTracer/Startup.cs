using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// hsh6679
// in order for static files to be served, you must configure the Middleware to add static files to the pipeline
//  - the static file middleware can be configured by adding a dependency on the Microsoft.AspNetCore.StaticFiles package to your project then calling the 'UseStaticFiles'
//    extension method from Startup.Configure
using Microsoft.AspNetCore.StaticFiles;

namespace PathTracer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // hsh6679 - starting index.html
            // setting a default home page gives site visitors a place to start when visiting your site
            //  - UseDefaultFiles must be called before UseStaticFiles to serve the default file
            //  - UseDefaultFiles is a URL re-writter that doesn't actually serve the file
            //  - You must enable the staticc file middleware (UseStaticFiles) to serve the file
            //  - With UseDefaultFiles, requests to a folder will search for:
            //      - default.htm, default.html, index.htm, index.html

            DefaultFilesOptions Options = new DefaultFilesOptions();
            Options.DefaultFileNames.Clear();
            Options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(Options);

            // it makes the files in web root (wwwroot by default) servable
            app.UseStaticFiles();

            /*
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            */
        }
    }
}
