using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeeApp.DbContext;
using EmployeeApp.Views.Constituencies;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.ViewModels
{
    public partial class ConstituencyListViewModel : LocalBaseViewModel
    {
        public ObservableRangeCollection<Constituency> ConstituenciesList { get; set; } = new ObservableRangeCollection<Constituency>();

        public ConstituencyListViewModel()
        {
            LoadConstituencies();
        }


        public void LoadConstituencies()
        {
            ConstituenciesList.Clear();
            var allConstituency = App.Database.GetTableRows<Constituency>("Constituency").ToList();
            ConstituenciesList.AddRange(allConstituency);

        }


       



        [RelayCommand]
        public async void AddNewConstituency()
        {
            await AppShell.Current.GoToAsync(nameof(AddNewConstituencyPage));
        }

    }
}
