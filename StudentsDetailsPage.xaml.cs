using EmployeeApp.ViewModels;

namespace EmployeeApp;

public partial class StudentsDetailsPage : ContentPage
{
	public StudentsDetailsPage(StudentsDetailsPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}