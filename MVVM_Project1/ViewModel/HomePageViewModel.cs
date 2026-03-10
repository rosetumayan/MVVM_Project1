using MVVM_Project1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM_Project1.ViewModel
{
    internal class HomePageViewModel:ObservableObject
    {
        public ObservableCollection<LostItems> LostItemsList { get; set; }
        //data
        public UserModel LoggedInUser { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand ReportLostCommand { get; set; }
        public ICommand ViewFoundItemsCommand { get; set; }

        public ICommand AddNewLostItemCommand { get; set; }

        public HomePageViewModel(UserModel CurrentUser)
        {
            LostItemsList = new ObservableCollection<LostItems>()
            {
                new LostItems { ItemName = " Wallet", Description = "Black", Location = "Library", DateReported = new DateTime(2024, 5, 10), IsFound = true },
                new LostItems { ItemName = " Keys", Description = "Set of 3", Location = "Cafeteria", DateReported = new DateTime(2024, 5, 12), IsFound = true },
                new LostItems { ItemName = " Backpack", Description = "Blue with white stripes", Location = "Gym", DateReported = new DateTime(2024, 5, 15), IsFound = false },
                new LostItems { ItemName = " Phone", Description = "iPhone 12", Location = "Lecture Hall", DateReported = new DateTime(2024, 5, 18), IsFound = false },
                new LostItems { ItemName = " Sunglasses", Description = "Ray-Ban Aviators", Location = "Park", DateReported = new DateTime(2024, 5, 20), IsFound = false }

            };

            LoggedInUser = CurrentUser;
            LogoutCommand = new RelayCommand(ExecuteLogout);
            ExitCommand = new RelayCommand(ExecuteExit);
            ReportLostCommand = new RelayCommand(ExecuteReportLost);
            ViewFoundItemsCommand = new RelayCommand(ExecuteViewFoundItems);
            AddNewLostItemCommand = new RelayCommand(ExecuteAddNewLostItem);
        }

        private void ExecuteAddNewLostItem(object? obj)
        {

            var formViewModel = new AddLostItemsViewModel(LostItemsList);
            var formWindow = new View.Window1{ DataContext = formViewModel};
            formWindow.ShowDialog();
            

        }

        public void ExecuteLogout(object? par)
        {
            var loginWindow = new View.User_Login();
            loginWindow.Show();
            //close the current main window
            Application.Current.MainWindow.Close();
        }

        public void ExecuteExit(object? par)
        {
            Application.Current.Shutdown();
        }

        public void ExecuteReportLost(object? par)
        {
            MessageBox.Show("Your report has been submitted. Please check your campus email for updates.", "Report Submitted", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ExecuteViewFoundItems(object? par)
        {
            MessageBox.Show("This feature is coming soon!", "Coming Soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
