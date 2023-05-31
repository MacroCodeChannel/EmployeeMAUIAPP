using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Views.SubLocations;
using MvvmHelpers;
using EmployeeApp.DbContext;

namespace EmployeeApp.ViewModels
{
    public partial class SubLocationListViewModel : LocalBaseViewModel
    {
        public ObservableRangeCollection<SubLocation> SubLocationsList { get; set; } = new ObservableRangeCollection<SubLocation>();
        public SubLocationListViewModel()
        {
            LoadSubLocations();
        }

        public void LoadSubLocations()
        {
            SubLocationsList.Clear();
            var allsublocations = App.Database.GetTableRows<SubLocation>("SubLocation").ToList();
            SubLocationsList.AddRange(allsublocations);

        }

        [RelayCommand]
        public async void AddNewSubLocation()
        {
            await AppShell.Current.GoToAsync(nameof(AddNewSubLocationPage));
        }
    }
}
