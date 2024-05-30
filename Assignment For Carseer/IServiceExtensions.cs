using Assignment_For_Carseer.Domain.Settings;
using Assignment_For_Carseer.Integration;
using Assignment_For_Carseer.Integration.Vehicles;
using Assignment_For_Carseer.Services.CarMakes;
using Assignment_For_Carseer.Services.Models;
using Refit;

namespace Assignment_For_Carseer
{
    public static class IServiceExtensions
    {
        public static void RegisterAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection configurationSection = configuration.GetSection("AppSettings");
            AppSettings appSettings = configurationSection.Get<AppSettings>();
            services.AddSingleton(appSettings);
        }

        public static void RegisterSerivces(this IServiceCollection services)
        {
            services.AddScoped<ICarMakeService, CarMakeService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IVehicleService, VehicleService>();
        }


        public static void RegisterRefit(this IServiceCollection services, IConfiguration configuration)
        {
            // get appsettings here to get url path
            IConfigurationSection configurationSection = configuration.GetSection("AppSettings");
            AppSettings appSettings = configurationSection.Get<AppSettings>();

            services
            .AddRefitClient<IVehicleApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(appSettings.VehicleSettings.Url));
        }

    }
}
