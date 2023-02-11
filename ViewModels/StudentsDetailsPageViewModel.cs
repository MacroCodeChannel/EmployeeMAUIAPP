using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.ViewModels
{
    public partial class StudentsDetailsPageViewModel :ObservableObject
    {
        public StudentsDetailsPageViewModel()
        {

        }

        [ICommand]
        private async void PreviousPage()
        {
            await Shell.Current.GoToAsync($"{nameof(StudentsListPage)}");
        }
    }
}
