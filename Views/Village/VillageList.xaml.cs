using EmployeeApp.ViewModels;

namespace EmployeeApp.Views.Village;

public partial class VillageList : ContentPage
{
	private VillagesListViewModel viewModel;
	public VillageList(VillagesListViewModel model)
	{
		InitializeComponent();
		this.BindingContext= viewModel = model;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is VillagesListViewModel bindingContext)
        {
            bindingContext.OnAppearing();
            viewModel.LoadVillages();
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        viewModel.VillageList.Clear();
    }
}