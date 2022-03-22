using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace openencoder
{
    public class Server
    {
        public Server(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(new WebApplicationOptions { ApplicationName = "OpenEncoder", Args = args });
            int port = builder.Configuration.GetValue<int>("server_port");
            builder.WebHost.UseAzureAppServices();//.UseKestrel(k => k.Listen(System.Net.IPAddress.Any, port));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<OpenEncoderModel>();
            builder.Services.AddMvc().AddMicrosoftIdentityUI();
            builder.Services.ConfigureApplicationCookie(options => options.LoginPath = new PathString("/dashboard/login"));
            builder.Services.AddTokenAuthentication()
            .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"))
            .EnableTokenAcquisitionToCallDownstreamApi()
            .AddInMemoryTokenCaches();
            WebApplication? app = builder.Build();
            app.UseSwagger(a => a.SerializeAsV2 = true);
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpLogging();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = new PathString("/dashboard")
            });
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.None, HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.None, Secure = CookieSecurePolicy.None });
            app.UseDefaultFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
            Console.WriteLine($"Started server on port: {port}");
            app.Run();
        }
    }
}
