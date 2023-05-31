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
    public partial class AddNewLocationPageViewModel :LocalBaseViewModel
    {
        public ObservableRangeCollection<Constituency> ConstituencyList { get; set; } = new ObservableRangeCollection<Constituency>();

        public AddNewLocationPageViewModel()
        {
            LocationDetails = new Locations();

            LoadConstituencies();
        }

        public void LoadConstituencies()
        {
            ConstituencyList.Clear();
            var allconstituencies = App.Database.GetTableRows<Constituency>("Constituency").ToList();
            ConstituencyList.AddRange(allconstituencies);

        }

        public Locations LocationDetails {  get; set; }

        public Constituency _selectedConstituency;
        public Constituency SelectedConstituency
        {
            get => _selectedConstituency;
            set
            {
                if (_selectedConstituency == value) return;
                _selectedConstituency = value;
            }
        }

        [RelayCommand]
        public async void AddNewLocations()
        {
            var locadata = this.LocationDetails;

            if (SelectedConstituency == null)
            {
                await Shell.Current.DisplayAlert("Select Constituency", "Please select Constituency", "OK");
                return;
            }

            locadata.ConstituencyId = SelectedConstituency.Id;

            var response = await App.Database.CreateAsync(locadata);
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Location Saved", "Location Details Successfully submitted", "OK");

                //Redirect to our list page
                await Shell.Current.GoToAsync("..");

            }
            else
            {
                await Shell.Current.DisplayAlert("Location Not Saved", "Something went wrong with the Location Details", "OK");

            }
        }
    }
}
