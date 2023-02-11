using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.ViewModels
{
    public partial class StudentsListPageViewModel : ObservableObject
    {

        public StudentsListPageViewModel()
        {

        }

       [ICommand]
        private async void NextPage()
        {
            await Shell.Current.GoToAsync($"{nameof(StudentsDetailsPage)}");
        } 
    }
   
}
