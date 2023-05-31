using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeeApp.DbContext;
using EmployeeApp.Views.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.ViewModels
{
    public partial class AddNewCountryPageViewModel :ObservableObject
    {

        public AddNewCountryPageViewModel()
        {
            CountryDetails = new Country();

        }

        public Country CountryDetails { get; set; }



        [RelayCommand]
        public async void AddNewCountry()
        {
            var countrydata = this.CountryDetails;

             var response = await App.Database.CreateAsync(countrydata);
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Country Saved", "Country Details Successfully submitted", "OK");

                //Redirect to our list page
                //await Shell.Current.GoToAsync($"{nameof(CountriesList)}");
                await Shell.Current.GoToAsync("..");

            }
            else
            {
                await Shell.Current.DisplayAlert("Country Not Saved", "Something went wrong with the Country Details", "OK");

            }
        }
    }
}
