using EmployeeApp.ViewModels;

namespace EmployeeApp;

public partial class EmployeesList : ContentPage
{
	public EmployeesViewModel _viemodel;
    public EmployeesList(EmployeesViewModel viewModel)
	{
		InitializeComponent();
        _viemodel=viewModel;
        this.BindingContext = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		{
			_viemodel.GetEmployeesListCommand.Execute(null);
		}
	}
}