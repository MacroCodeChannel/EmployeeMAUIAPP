
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeeApp.DbContext;
using EmployeeApp.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeApp.ViewModels
{

    public partial class AddEmployeeViewModel : LocalBaseViewModel
    {

        public ObservableRangeCollection<Constituency> allConstituencies = new ObservableRangeCollection<Constituency>();
        public ObservableRangeCollection<Country> allCountries = new ObservableRangeCollection<Country>();
        public ObservableRangeCollection<Locations> allLocations = new ObservableRangeCollection<Locations>();
        public ObservableRangeCollection<SubLocation> allSubLocation = new ObservableRangeCollection<SubLocation>();
        public ObservableRangeCollection<Village> allVillages = new ObservableRangeCollection<Village>();
        public AddEmployeeViewModel(int id = 0)
        {
            if(id > 0)
            {
                var data = App.Database.GetTableRow("Employee", "Id", id.ToString());
                EmployeeDetails = (Employee)data;
                CompleteEmployeePhotoPath = EmployeeDetails.EmployeePhoto;
                IsEdit = true;  
            }
            else
            {
                EmployeeDetails = new Employee();
                IsEdit = false;
            }


            //Loading Automatically
            var allConstituency = App.Database.GetTableRows<Constituency>("Constituency").ToList();
            LoadConstituencies.AddRange(allConstituency);

            var allCountries = App.Database.GetTableRows<Country>("Country").ToList();
            LoadCountries.AddRange(allCountries);

            var allLocations = App.Database.GetTableRows<Locations>("Locations").ToList();
            LoadLocations.AddRange(allLocations);

            var allsublocations = App.Database.GetTableRows<SubLocation>("SubLocation").ToList();
            LoadSubLocation.AddRange(allsublocations);

            var allvillages = App.Database.GetTableRows<Village>("Village").ToList();
            LoadVillages.AddRange(allvillages);

            if(EmployeeDetails != null && id > 0)
            {

                SelectedVillage = LoadVillages.FirstOrDefault(x => x.Id == EmployeeDetails.VillageId);

                SelectedSubLocation = LoadSubLocation.FirstOrDefault(x => x.Id == SelectedVillage.SubLocationId);

                SelectedLocation = LoadLocations.FirstOrDefault(x => x.Id == SelectedSubLocation.LocationIdId);

                SelectedConstituency = LoadConstituencies.FirstOrDefault(x => x.Id == SelectedLocation.ConstituencyId);

                SelectedCountry = LoadCountries.FirstOrDefault(x => x.Id == SelectedConstituency.CountryId);
            }



            CaptureEmployeePhotoCommand = new Command(DoCaptureEmployeePhoto, () => MediaPicker.IsCaptureSupported);

        }


        public ICommand CaptureEmployeePhotoCommand { get; }


        private async void DoCaptureEmployeePhoto()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                CompleteEmployeePhotoPath = await LoadPhotoAsync(photo);
                Console.WriteLine("Employee Photo Captured" + CompleteEmployeePhotoPath);
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        private string employeePhotoPath;
        public string CompleteEmployeePhotoPath
        {
            get => employeePhotoPath;
            set
            {
                SetProperty(ref employeePhotoPath, value);
                HasPhoto = !string.IsNullOrEmpty(value);
            }
        }

        private bool _hasPhoto;
        public bool HasPhoto
        {
            get => _hasPhoto;
            set=>SetProperty(ref _hasPhoto, value);

        }



        private bool isRunning = false;
        public bool IsRunning
        {
            set => SetProperty(ref isRunning, value);
            get => isRunning;
        }

        private bool isEdit = false;
        public bool IsEdit
        {
            set=>SetProperty(ref isEdit, value);
            get=> isEdit;
        }



        public Employee EmployeeDetails { get; set; }

        public ObservableRangeCollection<Village> LoadVillages
        {
            get => allVillages;
            set => SetProperty(ref allVillages, value);

        }


        public ObservableRangeCollection<SubLocation> LoadSubLocation
        {
            get => allSubLocation;
            set => SetProperty(ref allSubLocation, value);

        }

        public ObservableRangeCollection<Locations> LoadLocations
        {
            get => allLocations;
            set => SetProperty(ref allLocations, value);

        }

        public ObservableRangeCollection<Country> LoadCountries
        {
            get => allCountries;
            set => SetProperty(ref allCountries, value);

        }

        public ObservableRangeCollection<Constituency> LoadConstituencies
        {
            get => allConstituencies;
            set => SetProperty(ref allConstituencies,value);

        }

       


        public Country _selectedCountry;
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                if (_selectedCountry == value) return;
                _selectedCountry = value;
                if(_selectedCountry != null)
                {
                    var countryConstituencies = LoadConstituencies.Where(x => x.CountryId == _selectedCountry.Id).ToList();
                    LoadConstituencies.AddRange(countryConstituencies);
                }
            }
        }


        public Constituency _selectedConstituency;
        public Constituency SelectedConstituency
        {
            get => _selectedConstituency;
            set
            {
                if (_selectedConstituency == value) return;
                _selectedConstituency = value;
                if (_selectedConstituency != null)
                {
                    var countryLocations = LoadLocations.Where(x => x.ConstituencyId == _selectedConstituency.Id).ToList();
                    LoadLocations.AddRange(countryLocations);
                }
            }
        }

        public Locations _selectedLocation;
        public Locations SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                if (_selectedLocation == value) return;
                _selectedLocation = value;
                if (_selectedLocation != null)
                {
                    var countrysublocations = LoadSubLocation.Where(x => x.LocationIdId == _selectedLocation.Id).ToList();
                    LoadSubLocation.AddRange(countrysublocations);
                }
            }
        }

        public SubLocation _selectedSubLocation;
        public SubLocation SelectedSubLocation
        {
            get => _selectedSubLocation;
            set
            {
                if (_selectedSubLocation == value) return;
                _selectedSubLocation = value;
                if (_selectedSubLocation != null)
                {
                    var countryVillages = LoadVillages.Where(x => x.SubLocationId == _selectedSubLocation.Id).ToList();
                    LoadVillages.AddRange(countryVillages);
                }
            }
        }

        public Village _selectedVillage;
        public Village SelectedVillage
        {
            get => _selectedVillage;
            set
            {
                if (_selectedVillage == value) return;
                _selectedVillage = value;
            }
        }

        [RelayCommand]
        public async void DeleteEmployeeRecord()
        {
            if (IsRunning)
                return;

            IsRunning = true;
            var emdata = this.EmployeeDetails;

            if (emdata != null)
            {
                await App.Database.DeleteAsysnc<Employee>(emdata);
              
                await Shell.Current.DisplayAlert("Record Deleted", "Employee Details Successfully Deleted", "OK");
              
                //Navigate back to the list
                await Shell.Current.GoToAsync("..");
                IsRunning = false;
            }
            else
            {
                await Shell.Current.DisplayAlert("Record Missing", "Employee Details is missing", "OK");
                IsRunning = false;
                return;
            }
        }


        [RelayCommand]
        public async  void AddEmployee()
        {
            if (IsRunning)
                return;

            IsRunning = true;
            var emdata = this.EmployeeDetails;

            if(SelectedVillage != null)
            {
                emdata.VillageId = SelectedVillage.Id;
            }
            else
            {
                await Shell.Current.DisplayAlert("Select Village", "Please select the village", "OK");
                IsRunning = false;
                return;
            }

            emdata.EmployeePhoto = CompleteEmployeePhotoPath;


            var response = await App.Database.AddOrUpdateAsync(emdata);
            await Shell.Current.DisplayAlert("Record Added", "Employee Details Successfully submitted", "OK");
            IsRunning = false;
            //Navigate back to the list
            await Shell.Current.GoToAsync("..");
           
            /*
            if(!IsEdit)
            {
                var response = await App.Database.CreateAsync(emdata);
                await Shell.Current.DisplayAlert("Record Added", "Employee Details Successfully submitted", "OK");
                //Navigate back to the list
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                var response = await App.Database.UpdateAsync(emdata);
                await Shell.Current.DisplayAlert("Record Updated", "Employee Details Successfully Updated", "OK");
                //Navigate back to the list
                await Shell.Current.GoToAsync("..");
            }
            */
        }

     
    }
}
