
using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.Country;

public partial class AddNewCountryPage : ContentPage
{
	public AddNewCountryPageViewModel viewModel;
    public AddNewCountryPage(AddNewCountryPageViewModel model)
	{
		InitializeComponent();
		this.BindingContext = viewModel = model;
	}
}