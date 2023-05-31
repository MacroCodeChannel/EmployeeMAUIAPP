using EmployeeApp.DbContext;
using EmployeeApp.Services;
using EmployeeApp.ViewModels;
using EmployeeApp.Views.Country;
using EmployeeApp.Views.Constituencies;
using EmployeeApp.Views.SubLocations;
using EmployeeApp.Views.Locations;
using EmployeeApp.Views.Village;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        //Services
        
        builder.Services.AddSingleton<ApplicationDbContext>();
        builder.Services.AddSingleton<IEmployeeService,EmployeeService>();
        builder.Services.AddSingleton<ProductService>();

        //Views
        builder.Services.AddSingleton<EmployeesList>();
        builder.Services.AddTransient<AddEmployee>();
        builder.Services.AddTransient<CountriesList>();
        builder.Services.AddTransient<ConstituencyList>();
        builder.Services.AddTransient<LocationsList>();
        builder.Services.AddTransient<SubLocationsList>();
        builder.Services.AddTransient<VillageList>();
        builder.Services.AddTransient<AddNewCountryPage>();
        builder.Services.AddTransient<AddNewConstituencyPage>();
        builder.Services.AddTransient<AddNewLocationPage>();
        builder.Services.AddTransient<AddNewSubLocationPage>();
        builder.Services.AddTransient<AddNewVillagePage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddTransient<DashboardPage>();

        

        //View Models
        builder.Services.AddSingleton<EmployeesViewModel>();
        builder.Services.AddTransient<AddEmployeeViewModel>();
        builder.Services.AddTransient<CountriesListViewModel>();
        builder.Services.AddTransient<ConstituencyListViewModel>();
        builder.Services.AddTransient<LocationsListViewModel>();
        builder.Services.AddTransient<SubLocationListViewModel>();
        builder.Services.AddTransient<VillagesListViewModel>();
        builder.Services.AddTransient<AddNewCountryPageViewModel>();
        builder.Services.AddTransient<AddNewConstituencyPageViewModel>();
        builder.Services.AddTransient<AddNewLocationPageViewModel>();
        builder.Services.AddTransient<AddNewSubLocationPageViewModel>();
        builder.Services.AddTransient<AddNewVillagePageViewModel>();
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddTransient<DashboardPageViewModel>();
        

        return builder.Build();
	}
}
