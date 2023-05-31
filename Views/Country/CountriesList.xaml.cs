using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.Country;

public partial class CountriesList : ContentPage
{
	private CountriesListViewModel viewModel;
	public CountriesList(CountriesListViewModel model)
	{
		InitializeComponent();
		this.BindingContext = viewModel = model;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is CountriesListViewModel bindingContext)
        {
            bindingContext.OnAppearing();
            viewModel.LoadCountries();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        viewModel.CountriesList.Clear();
    }
}