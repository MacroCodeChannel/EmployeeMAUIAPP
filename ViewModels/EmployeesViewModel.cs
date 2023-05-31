using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeeApp.DbContext;
using EmployeeApp.Services;
using MvvmHelpers;

namespace EmployeeApp.ViewModels
{
    public partial class EmployeesViewModel : LocalBaseViewModel
    {
        public ObservableRangeCollection<Employee> Employees { get; set; } = new ObservableRangeCollection<Employee>();
        public EmployeesViewModel()
        {
            LoadEmployees();
        }


        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged();
                if(selectedEmployee == null)
                {
                    return;
                }
                OnSelectedEmployee(value);

            }
        }

        private async void OnSelectedEmployee(Employee employee)
        {
            try
            {
                if(employee == null)
                {
                    return;
                }
                else
                {
                    await Shell.Current.GoToAsync($"{nameof(AddEmployee)}?{nameof(AddEmployee.EmployeeId)}={employee.Id}");
                }

            }catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error Occured", "Something went wrong while selecting the employee" + ex.Message, "OK");
            }
        }




        public  void LoadEmployees()
        {

            var employees = App.Database.GetTableRows<Employee>("Employee").ToList();
            if(employees?.Count > 0)
            {
                Employees.Clear();
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }

        }

        [RelayCommand]
        public async void AddUpdateEmployee()
        {
            await AppShell.Current.GoToAsync(nameof(AddEmployee));
        }


    }
}
