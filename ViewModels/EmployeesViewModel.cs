using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Models;
using EmployeeApp.Services;

namespace EmployeeApp.ViewModels
{
    public partial class EmployeesViewModel : ObservableObject
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
       
        public readonly IEmployeeService _employeeService;
        public EmployeesViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [ICommand]
        public async  void GetEmployeesList()
        {

            var employees = await _employeeService.GetEmployeesList();
            if(employees?.Count > 0)
            {
                Employees.Clear();
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }

        }

        [ICommand]
        public async void AddUpdateEmployee()
        {
            await AppShell.Current.GoToAsync(nameof(AddEmployee));
        }


        [ICommand]
        public async void DisplayAction(Employee employee)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");

            if (response == "Edit")
            {
                var navparam = new Dictionary<string, object>();
                navparam.Add("AddEmployee", employee);

                await AppShell.Current.GoToAsync(nameof(AddEmployee), navparam);
            }
            if (response == "Delete")
            {
                var deletresponse = await _employeeService.DeleteEmployee(employee);

                if (deletresponse > 0)
                {
                    GetEmployeesList();
                }
            }

        }
    }
}
