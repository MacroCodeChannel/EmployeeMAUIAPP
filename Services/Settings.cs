using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public partial class Settings : ObservableObject
    {


        private static Settings settings;

        public static Settings Current
        {
            get
            {
                return settings??(settings=new Settings()); 
            }
        }

        public const string LoggedInKey = "logged_in";

        public bool LoggedIn
        {
            get
            {
                return Preferences.Default.Get<bool>(LoggedInKey, default);
            }
            set
            {
                Preferences.Default.Set(LoggedInKey, value);
            }
        }
    }
}
