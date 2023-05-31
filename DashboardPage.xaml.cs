using EmployeeApp.ViewModels;

namespace EmployeeApp;

public partial class DashboardPage : ContentPage
{

	public DashboardPageViewModel vm;
    public DashboardPage(DashboardPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = vm = viewModel;	
	}
}