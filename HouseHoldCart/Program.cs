using Microsoft.EntityFrameworkCore;
using HouseHoldCart.Middleware;
using HouseHoldCart.DataAccess;

namespace HouseHoldCart
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            ConfigureServices(builder.Services);

            var app = builder.Build();

            Configure(app);

            app.Run();
        }

        public static void Configure(WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<JwtAuthenticationMiddleware>();

            app.MapControllers();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient();

            AddDependancy(services);
            ConfigureMediateRServices(services);
        }
    }
}
