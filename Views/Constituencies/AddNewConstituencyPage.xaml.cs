using EmployeeApp.ViewModels;
namespace EmployeeApp.Views.Constituencies;

public partial class AddNewConstituencyPage : ContentPage
{

	public AddNewConstituencyPageViewModel viewModel;
    public AddNewConstituencyPage(AddNewConstituencyPageViewModel model)
	{
		InitializeComponent();
		this.BindingContext = viewModel = model;
	}
}