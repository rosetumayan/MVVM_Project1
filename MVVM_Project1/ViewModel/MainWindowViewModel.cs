using MVVM_Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM_Project1.ViewModel
{
    internal class MainWindowViewModel: ObservableObject

    {
        //Data
        public UserModel CurrentUser { get; set; }

        //Create a public property of ICommand type
        public ICommand GoToLogin {get; set;}

        public MainWindowViewModel()
        {
            CurrentUser = new UserModel();
            //Initialize the command and link it to the method
            GoToLogin = new RelayCommand(ExecuteGoToLogin);
        }

        private void ExecuteGoToLogin(object? par)
        {
            var password = par as PasswordBox;
            if (password != null) {
                CurrentUser.Password = password.Password;
            }
            if (CurrentUser.Username.Trim() == "admin" && CurrentUser.Password.Trim() == "1234")
            {
                var loginWindow = new View.User_Login();
                loginWindow.Show();
                //close the current main window
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
