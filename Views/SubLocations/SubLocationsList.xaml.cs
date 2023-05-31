using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.SubLocations;

public partial class SubLocationsList : ContentPage
{
	private SubLocationListViewModel viewModel;
	public SubLocationsList(SubLocationListViewModel model)
	{
		InitializeComponent();
		this.BindingContext = viewModel = model ;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is SubLocationListViewModel bindingContext)
        {
            bindingContext.OnAppearing();
            viewModel.LoadSubLocations();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        viewModel.SubLocationsList.Clear();
    }
}