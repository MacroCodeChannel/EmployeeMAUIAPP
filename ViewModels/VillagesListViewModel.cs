using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Views.Village;
using MvvmHelpers;
using EmployeeApp.DbContext;

namespace EmployeeApp.ViewModels
{
    public partial class VillagesListViewModel : LocalBaseViewModel
    {

        public ObservableRangeCollection<Village> VillageList { get; set; } = new ObservableRangeCollection<Village>();
        public VillagesListViewModel()
        {
            LoadVillages();
        }
        public void LoadVillages()
        {
            VillageList.Clear();
            var allvillages = App.Database.GetTableRows<Village>("Village").ToList();
            VillageList.AddRange(allvillages);

        }

        [RelayCommand]
        public async void AddNewVillage()
        {
            await AppShell.Current.GoToAsync(nameof(AddNewVillagePage));
        }
    }
}
