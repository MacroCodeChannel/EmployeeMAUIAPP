using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.SubLocations;

public partial class AddNewSubLocationPage : ContentPage
{
	public AddNewSubLocationPageViewModel viewModel;
    public AddNewSubLocationPage(AddNewSubLocationPageViewModel model)
	{
		InitializeComponent();

		this.BindingContext = viewModel = model;
	}
}