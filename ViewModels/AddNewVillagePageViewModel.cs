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
    public partial class AddNewVillagePageViewModel : LocalBaseViewModel
    {
        public ObservableRangeCollection<SubLocation> SubLocationList { get; set; } = new ObservableRangeCollection<SubLocation>();
        public AddNewVillagePageViewModel()
        {
            VillageDetails = new Village();
            LoadSubLocations();
        }


        public Village VillageDetails { get; set; }

        public void LoadSubLocations()
        {
            SubLocationList.Clear();
            var allsublocation = App.Database.GetTableRows<SubLocation>("SubLocation").ToList();
            SubLocationList.AddRange(allsublocation);

        }

        public SubLocation _selectedSubLocation;
        public SubLocation SelectedSubLocation
        {
            get => _selectedSubLocation;
            set
            {
                if (_selectedSubLocation == value) return;
                _selectedSubLocation = value;
            }
        }

        [RelayCommand]
        public async void AddNewVillage()
        {
            var villageData = this.VillageDetails;

            if (SelectedSubLocation == null)
            {
                await Shell.Current.DisplayAlert("Select SubLocation", "Please select SubLocation", "OK");
                return;
            }

            villageData.SubLocationId = SelectedSubLocation.Id;

            var response = await App.Database.CreateAsync(villageData);
            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Village Saved", "Village Details Successfully submitted", "OK");

                //Redirect to our list page
                await Shell.Current.GoToAsync("..");

            }
            else
            {
                await Shell.Current.DisplayAlert("Village Not Saved", "Something went wrong with the Village Details", "OK");

            }
        }
    }
}
