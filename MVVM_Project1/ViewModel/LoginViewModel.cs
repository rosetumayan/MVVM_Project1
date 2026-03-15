using MVVM_Project1.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace MVVM_Project1.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        //This property represents the current user and is bindable to the view.
        //It will hold the username and password entered by the user.
        // The UserModel class is likely a simple model class that contains properties for Username, Password,
        // and possibly other user-related information that are defined in the Model folder of the MVVM project.
        public UserModel CurrentUser { get; set; }

        //This property represents the command that will be executed when the user clicks the login button in the view.
        // The ICommand interface is part of the System.Windows.Input namespace and is used to define commands in WPF applications.
        // The RelayCommand class is a common implementation of the ICommand interface that allows you to pass a method to be executed when the command is triggered.
        public ICommand LoginCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; }

        public ICommand ButtonMinimizedCommand { get; set; }

        public ICommand ButtonMaximizedCommand { get; set; }

        public ICommand ButtonCloseCommand { get; set; }

        public ICommand WindowDragCommand { get; set; }


        //viewmodel constructor where we initialize the data and commands    
        public LoginViewModel()
        {
            CurrentUser = new UserModel();
            LoginCommand = new RelayCommand(ExecuteLogin);
            ForgotPasswordCommand = new RelayCommand(ExecuteForgotPassword);
            ButtonMinimizedCommand = new RelayCommand(ExecuteButtonMinimized);
            ButtonMaximizedCommand = new RelayCommand(ExecuteButtonMaximized);
            ButtonCloseCommand = new RelayCommand(ExecuteButtonClose);
            WindowDragCommand = new RelayCommand(ExecuteWindowDrag);
        }

        //command methods that will be executed when the command is triggered through the RelayCommand


        // In the ExecuteLogin method, we first check if the parameter passed is a PasswordBox.
        // If it is, we retrieve the password from the PasswordBox and set it to the CurrentUser's Password property.
        // Then we check if the username and password match the hardcoded values ("admin" and "1234").
        // If they do, we create a new instance of HomePageViewModel, passing the CurrentUser as a parameter,
        // and then create and show a new HomePage window with this ViewModel as its DataContext.
        // Finally, we close the current main window. If the username or password is incorrect, we display an error message.
        private void ExecuteLogin(object? parameter)
        {
            var password = parameter as PasswordBox;
            if (password != null)
            {
                CurrentUser.Password = password.Password;
            }
            if (CurrentUser.Username.Trim() == "admin" && CurrentUser.Password.Trim() == "1234")
            {

                var newViewModel = new HomePageViewModel(CurrentUser);
                var loginWindow = new View.HomePage();
                loginWindow.DataContext = newViewModel;
                loginWindow.Show();
                //close the current main window
                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExecuteForgotPassword(object? par)
        {
            CurrentUser.StatusMessage = "Instructions sent to your campus email.";
        }

        private void ExecuteButtonMinimized(object? par)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;

        }

        private void ExecuteButtonMaximized(object? par)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
                //change the image source to the maximize icon
                var newimage = par as Image;
                if (newimage is Image img)
                {
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/window-maximize.png"));
                }
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                //change the image source to the restore icon
                var newimage = par as Image;
                if (newimage is Image img)
                {
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/window-restore.png"));
                }

            }
        }

        private void ExecuteButtonClose(object? par)
        {
            Application.Current.Shutdown();
        }

        private void ExecuteWindowDrag(object? par)
        {
            Application.Current.MainWindow.DragMove();
        }
    }
}
