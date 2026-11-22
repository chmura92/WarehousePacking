
using WarehousePacking.Application.UseCases.CalculatePacking;
using WarehousePacking.Domain.Contracts;
using WarehousePacking.Infrastructure.Services;

namespace WarehousePacking.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
            // todo: refactor registrations as extension methods
			builder.Services.AddScoped<ICalculatePackingService, CalculatePackingService>();
			builder.Services.AddScoped<IBoxCapacityCalculator, DivisionCapacityCalculator>();
			builder.Services.AddScoped<ILpnGenerator, GuidLpnGenerator>();

			builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // todo add exception midleware

            app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

            app.Run();
        }
    }
}
