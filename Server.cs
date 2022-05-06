using Microsoft.Extensions.FileProviders;

namespace openencoder;
public class Server
{
    public Server(string[] args)
    {
        WebApplicationBuilder? builder = WebApplication.CreateBuilder(new WebApplicationOptions { ApplicationName = "OpenEncoder", Args = args });
        int port = builder.Configuration.GetValue<int>("server_port");
        builder.WebHost.UseKestrel(k => k.Listen(System.Net.IPAddress.Any, port));//.UseAzureAppServices();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<OpenEncoderModel>();
        WebApplication? app = builder.Build();
        app.UseSwagger(a => a.SerializeAsV2 = true);
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
        app.UseRouting();
        app.UseHttpLogging();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
            RequestPath = new PathString("/dashboard")
        });
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