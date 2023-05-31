using EmployeeApp.ViewModels;

namespace EmployeeApp;


public partial class EmployeesList : ContentPage
{
	public EmployeesViewModel _viemodel;
    public EmployeesList(EmployeesViewModel viewModel)
	{
		InitializeComponent();
       
        this.BindingContext = _viemodel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is EmployeesViewModel bindingContext)
        {
            bindingContext.OnAppearing();
            _viemodel.LoadEmployees();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viemodel.Employees.Clear();
    }
}