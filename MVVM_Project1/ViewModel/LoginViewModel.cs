using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MVVM_Project1.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set
            {
                if (value == null || _username == value) return;
                _username = value;
                OnPropertyChanged();
            }
        }

        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                if (value == null || _statusMessage == value) return;
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand LoginCommand { get; }
        public RelayCommand ForgotPasswordCommand { get; }

        public LoginViewModel()
        {
            // We pass 'parameter' (the PasswordBox) into our method
            LoginCommand = new RelayCommand((object? parameter) => ExecuteLogin(parameter));
            ForgotPasswordCommand = new RelayCommand(o => ExecuteForgotPassword());
        }

        private void ExecuteLogin(object? parameter)
        {
            // We cast the parameter back to a PasswordBox to read its content
            var passwordBox = parameter as PasswordBox;
            string password = passwordBox?.Password ?? string.Empty;

            // Simplified validation for Week 2-3
            if (Username.ToLower() == "admin" && password == "1234")
            {
                //StatusMessage = "Login Successful. Welcome, Admin!";
                MessageBox.Show("Login Successful. Welcome, Admin!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                StatusMessage = "Invalid Username or Password.";
            }
        }

        private void ExecuteForgotPassword()
        {
            StatusMessage = "Instructions sent to your campus email.";
        }
    }
}
