namespace EmployeeApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddEmployee), typeof(AddEmployee));
        Routing.RegisterRoute(nameof(StudentsDetailsPage), typeof(StudentsDetailsPage));
        Routing.RegisterRoute(nameof(StudentsListPage), typeof(StudentsListPage));

    }
}
