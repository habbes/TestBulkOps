

using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.ModelBuilder;
using TestBulkOps.Models;

namespace TestBulkOps
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            
            builder.Services.AddControllers();
            builder.Services.AddOData();
            builder.Services.AddRouting();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapODataRoute(
                    "odata", "odata", Model.GetModel());
            });

            app.MapControllers();

            app.Run();
        }
    }
}