using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.Locations;

public partial class LocationsList : ContentPage
{
	private LocationsListViewModel viewModel;
	public LocationsList(LocationsListViewModel model)
	{
		InitializeComponent();

		this.BindingContext = viewModel = model;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is LocationsListViewModel bindingContext)
        {
            bindingContext.OnAppearing();
            viewModel.LoadLocations();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        viewModel.LocationList.Clear();
    }
}