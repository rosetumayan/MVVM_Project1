using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM_Project1.View
{
    /// <summary>
    /// Interaction logic for User_Login.xaml
    /// </summary>
    public partial class User_Login : Window
    {
        public User_Login()
        {
            InitializeComponent();
           // this.DataContext = new ViewModel.LoginViewModel();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)    
            {
                DragMove();
            }
        }

        

       

        private void chkShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            txtPasswordVisible.Text = txtPassword.Password ?? string.Empty;
            txtPasswordVisible.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
        }

        private void chkShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = txtPasswordVisible.Text ?? string.Empty;
            txtPasswordVisible.Visibility = Visibility.Collapsed;
            txtPassword.Visibility = Visibility.Visible;
        }

        

        
    }
}
