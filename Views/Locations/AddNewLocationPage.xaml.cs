using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.Locations;

public partial class AddNewLocationPage : ContentPage
{
	public AddNewLocationPageViewModel viewModel;
    public AddNewLocationPage(AddNewLocationPageViewModel models)
	{
		InitializeComponent();
		this.BindingContext =viewModel =models;
	}
}