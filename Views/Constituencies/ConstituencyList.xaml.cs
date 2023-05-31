using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.Constituencies;

public partial class ConstituencyList : ContentPage
{
	private ConstituencyListViewModel viewModel;
	public ConstituencyList(ConstituencyListViewModel model)
	{
		InitializeComponent();

		this.BindingContext = viewModel = model;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		if(BindingContext is ConstituencyListViewModel bindingContext)
		{
			bindingContext.OnAppearing();
            viewModel.LoadConstituencies();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        viewModel.ConstituenciesList.Clear();
    }

}
