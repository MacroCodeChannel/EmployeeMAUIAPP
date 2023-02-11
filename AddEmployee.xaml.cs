using EmployeeApp.ViewModels;

namespace EmployeeApp;

public partial class AddEmployee : ContentPage
{
	public AddEmployee(AddEmployeeViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext = viewModel;
	}
}