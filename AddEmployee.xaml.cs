using EmployeeApp.ViewModels;

namespace EmployeeApp;


[QueryProperty(nameof(EmployeeId), nameof(EmployeeId))]
public partial class AddEmployee : ContentPage
{
    public AddEmployeeViewModel vm;
    public AddEmployee(AddEmployeeViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext = vm  =viewModel;
	}

    public string employeeId { get; set; }
    public string EmployeeId
    {
        get => employeeId;
        set
        {
            employeeId = value;
            BindingContext = vm = new AddEmployeeViewModel(int.Parse(Uri.UnescapeDataString(value)));
        }
    }
}