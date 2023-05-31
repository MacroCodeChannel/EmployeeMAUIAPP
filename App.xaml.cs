using EmployeeApp.DbContext;
using EmployeeApp.Services;

namespace EmployeeApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Database = new ApplicationDbContext();

        MainPage = new AppShell();

		//Check our Login Status
		CheckLoginStatusAsync();

    }

	public static ApplicationDbContext Database { get; private set; }


	public async void CheckLoginStatusAsync()
	{
		if(Settings.Current.LoggedIn==false)
		{
			await GoToLogin();
		}
		else
		{
			await GoToHome();

        }
	}

	public static System.Threading.Tasks.Task GoToLogin()
	{
		return Shell.Current.GoToAsync($"{nameof(LoginPage)}");
	}
    public static System.Threading.Tasks.Task GoToHome()
    {
        return Shell.Current.GoToAsync($"{nameof(DashboardPage)}");
    }
}
