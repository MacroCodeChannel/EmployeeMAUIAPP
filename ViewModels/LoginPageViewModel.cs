using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeApp.ViewModels
{
    public class LoginPageViewModel :LocalBaseViewModel
    {
        public LoginPageViewModel()
        {

        }

        public bool isRunning;
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetProperty(ref isRunning, value); }

        }

        public string emailAddress;
        public string EmailAdress
        {
            get { return emailAddress; }
            set { SetProperty(ref emailAddress, value); }

        }

        public string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }

        }

        private ICommand _loginCommand;
       public ICommand LoginCommand =>
            _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginAsync()));


        public async Task ExecuteLoginAsync()
        {
            if (IsRunning)
                return;
            IsRunning = true;   


            if(string.IsNullOrEmpty(EmailAdress))
            {
                await Shell.Current.DisplayAlert("Missing Email Address", "Please provide valid Email Address", "OK");
                IsRunning = false;
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Shell.Current.DisplayAlert("Missing Password", "Please provide valid Password", "OK");
                IsRunning = false;
                return;
            }
        }

    }
}

