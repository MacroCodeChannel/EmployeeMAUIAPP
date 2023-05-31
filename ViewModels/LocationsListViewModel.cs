using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Views.Locations;
using MvvmHelpers;
using EmployeeApp.DbContext;

namespace EmployeeApp.ViewModels
{
    public partial class LocationsListViewModel : LocalBaseViewModel
    {
        public ObservableRangeCollection<Locations> LocationList { get; set; } = new ObservableRangeCollection<Locations>();


        public LocationsListViewModel()
        {

            LoadLocations();
        }

        public void LoadLocations()
        {
            LocationList.Clear();
            var alllocation = App.Database.GetTableRows<Locations>("Locations").ToList();
            LocationList.AddRange(alllocation);

        }


        [RelayCommand]
        public async void AddNewLocation()
        {
            await AppShell.Current.GoToAsync(nameof(AddNewLocationPage));
        }
    }
    
}
