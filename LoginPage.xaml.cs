using EmployeeApp.ViewModels;

namespace EmployeeApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
		InitializeComponent();
		this.BindingContext = new LoginPageViewModel();
	}
}