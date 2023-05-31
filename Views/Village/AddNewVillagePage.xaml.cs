using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.Village;

public partial class AddNewVillagePage : ContentPage
{
	public AddNewVillagePageViewModel viewModel;
    public AddNewVillagePage(AddNewVillagePageViewModel model)
	{
		InitializeComponent();

		this.BindingContext = viewModel = model;
	}
}