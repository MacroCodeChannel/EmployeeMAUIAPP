using EmployeeApp.ViewModels;

namespace EmployeeApp;

public partial class StudentsListPage : ContentPage
{
	public StudentsListPage(StudentsListPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}