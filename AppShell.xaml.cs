using EmployeeApp.Views.Constituencies;
using EmployeeApp.Views.Country;
using EmployeeApp.Views.Locations;
using EmployeeApp.Views.SubLocations;
using EmployeeApp.Views.Village;

namespace EmployeeApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddEmployee), typeof(AddEmployee));
        Routing.RegisterRoute(nameof(AddNewCountryPage), typeof(AddNewCountryPage));
		Routing.RegisterRoute(nameof(CountriesList), typeof(CountriesList));
        Routing.RegisterRoute(nameof(AddNewConstituencyPage), typeof(AddNewConstituencyPage));
        Routing.RegisterRoute(nameof(AddNewLocationPage), typeof(AddNewLocationPage));
        Routing.RegisterRoute(nameof(AddNewSubLocationPage), typeof(AddNewSubLocationPage));
        Routing.RegisterRoute(nameof(AddNewVillagePage), typeof(AddNewVillagePage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));

    }
}
