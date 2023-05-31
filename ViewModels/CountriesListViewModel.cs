using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeeApp.DbContext;
using EmployeeApp.Views.Country;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.ViewModels
{
    public partial class CountriesListViewModel : LocalBaseViewModel
    {
        public ObservableRangeCollection<Country> CountriesList { get; set; } = new ObservableRangeCollection<Country>();

        public CountriesListViewModel()
        {
            LoadCountries();
        }


        public void LoadCountries()
        {
            CountriesList.Clear();
            var allcountries = App.Database.GetTableRows<Country>("Country").ToList();
            foreach(var country in allcountries)
            {
                CountriesList.Add(country);
            }

        }
      

        [RelayCommand]
        public async void AddNewCountry()
        {
            await AppShell.Current.GoToAsync(nameof(AddNewCountryPage));
        }

    }
}
