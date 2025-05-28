using HouseHoldCart.Application.Authentication;
using HouseHoldCart.Application.Authentication.Interfaces;
using HouseHoldCart.DataAccess;
using HouseHoldCart.DataAccess.Authentication;
using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.DataAccess.Orders;
using HouseHoldCart.DataAccess.Users;
using HouseHoldCart.DataAccess.HouseHoldItems;
using HouseHoldCart.Application.HouseHoldItems.Commands;
using System.Reflection;
using MediatR;

namespace HouseHoldCart
{
    public partial class Program
    {
        private static void AddDependancy(IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            // Application layer
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOtpService, OtpService>();

            // Data access layer
            services.AddScoped(typeof(ICrudOperation<>), typeof(CrudOperation<>));
            services.AddScoped<IOtpCodesDataAccess, OtpCodesDataAccess>();
            services.AddScoped<IRefreshTokenDataAccess, RefreshTokenDataAccess>();
            services.AddScoped<IUserDataAccess, UsersDataAccess>();
            services.AddScoped<IOrderDataAccess, OrderDataAccess>();
            services.AddScoped<IHouseHoldItemDataAccess, HouseHoldItemDataAccess>();

            //services.AddScoped<IProductDataAccess, ProductDataAccess>();
            //services.AddScoped<ICartDataAccess, CartDataAccess>();
            //services.AddScoped<IOrderItemDataAccess, OrderItemDataAccess>();
        }

        private static void ConfigureMediateRServices(IServiceCollection services)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            var logger = loggerFactory.CreateLogger<Program>();

            List<Assembly> assemblies = [typeof(CreateHouseHoldItemCommand).Assembly];
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(assemblies.ToArray()));
        }
    }
}
