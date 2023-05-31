using CommunityToolkit.Mvvm.Input;
using EmployeeApp.DbContext;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.ViewModels
{
    public partial class AddNewSubLocationPageViewModel : LocalBaseViewModel
    {
        public ObservableRangeCollection<Locations> LocationList { get; set; } = new ObservableRangeCollection<Locations>();
        public AddNewSubLocationPageViewModel()
        {

            SubLocationDetails = new SubLocation();
            LoadLocations();
        }
        public void LoadLocations()
        {
            LocationList.Clear();
            var alllocation = App.Database.GetTableRows<Locations>("Locations").ToList();
            LocationList.AddRange(alllocation);

        }

        public Locations _selectedLocation;
        public Locations SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                if (_selectedLocation == value) return;
                _selectedLocation = value;
            }
        }

        public SubLocation SubLocationDetails { get; set; }


        [RelayCommand]
        public async void AddNewSubLocations()
        {
            var sublocadata = this.SubLocationDetails;

            if (SelectedLocation == null)
            {
                await Shell.Current.DisplayAlert("Select Location", "Please select Location", "OK");
                return;
            }

            sublocadata.LocationIdId = SelectedLocation.Id;

            var response = await App.Database.CreateAsync(sublocadata);
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("SubLocation Saved", "SubLocation Details Successfully submitted", "OK");

                //Redirect to our list page
                await Shell.Current.GoToAsync("..");

            }
            else
            {
                await Shell.Current.DisplayAlert("SubLocation Not Saved", "Something went wrong with the SubLocation Details", "OK");

            }
        }
    }
}
