
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeeApp.DbContext;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.ViewModels
{
    public partial  class AddNewConstituencyPageViewModel  
    {
        public ObservableRangeCollection<Country> CountriesList { get; set; } = new ObservableRangeCollection<Country>();

        public AddNewConstituencyPageViewModel()
        {

            ConstituencyDetails = new Constituency();

            LoadCountries();
        }
        public void LoadCountries()
        {
            CountriesList.Clear();
            var allcountries = App.Database.GetTableRows<Country>("Country").ToList();
            CountriesList.AddRange(allcountries);

        }


        public Constituency ConstituencyDetails { get; set; }


        public Country _selectedCountry;
        public Country SelectedCountry
        {
            get=> _selectedCountry;
            set
            {
                if(_selectedCountry == value) return;
                _selectedCountry = value;
            }
        }

        [RelayCommand]
        public async void AddNewConstituency()
        {
            var constdata = this.ConstituencyDetails;
            if(SelectedCountry == null)
            {
                await Shell.Current.DisplayAlert("Select Country", "Please select Country", "OK");
                return;
            }

            constdata.CountryId= SelectedCountry.Id;

            var response = await App.Database.CreateAsync(constdata);
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Constituency Saved", "Constituency Details Successfully submitted", "OK");

                //Redirect to our list page
                await Shell.Current.GoToAsync("..");

            }
            else
            {
                await Shell.Current.DisplayAlert("Constituency Not Saved", "Something went wrong with the Constituency Details", "OK");

            }
        }
    }
}


