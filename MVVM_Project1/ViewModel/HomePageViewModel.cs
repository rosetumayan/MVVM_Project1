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
using System.IO;

namespace MVVM_Project1.ViewModel
{
    internal class HomePageViewModel:ObservableObject
    {
        public ObservableCollection<LostItems> LostItemsList { get; set; }
        //data
        public UserModel LoggedInUser { get; set; }

        public LostItems newLostItems { get; set; }
        

        private LostItems _selectedLostItems;
        public LostItems SelectedLostItems
        {
            get { return _selectedLostItems; }
            set
            {
                _selectedLostItems = value;
                OnPropertyChanged(nameof(SelectedLostItems));

                if (SelectedLostItems != null)
                {
                    newLostItems.ItemName = SelectedLostItems.ItemName;
                    newLostItems.Description = SelectedLostItems.Description;
                    newLostItems.Location = SelectedLostItems.Location;
                    newLostItems.DateReported = SelectedLostItems.DateReported;
                    newLostItems.IsFound = SelectedLostItems.IsFound;
                }

            }
        }

        public ICommand ShowHomePageCommand { get; set; }
        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand ClearCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        
      

       

        public HomePageViewModel(UserModel CurrentUser)
        {
            LostItemsList = new ObservableCollection<LostItems>();

            LoggedInUser = CurrentUser;
            newLostItems = new LostItems();
            _selectedLostItems = new LostItems();
            ShowHomePageCommand = new RelayCommand(ExecuteShowHomePage);
            SaveCommand = new RelayCommand(ExecuteSaveCommand);
            DeleteCommand = new RelayCommand(ExecuteDeleteCommand);
            ClearCommand = new RelayCommand(ExecuteClearCommand);
            LogoutCommand = new RelayCommand(ExecuteLogout);
            ExitCommand = new RelayCommand(ExecuteExit);
            LoadItemsFromFile();
            
        }

        private void LoadItemsFromFile()
        {
            string[] allLines = File.ReadAllLines("source.csv");

            foreach (string line in allLines)
            {
                
                string[] pieces = line.Split(',');

                
                LostItems item = new LostItems();
                item.ItemName = pieces[0];
                item.Description = pieces[1];
                item.Location = pieces[2];
                item.DateReported = DateTime.Parse(pieces[3]);
                item.IsFound = bool.Parse(pieces[4]);

                LostItemsList.Add(item);
            }
        }


        public void ExecuteShowHomePage(object? par)
        {
            // This method can be used to refresh the home page.
            // Refresh Current Window
                var homePageWindow = new View.HomePage();
                homePageWindow.DataContext = this; // Set the DataContext to the current ViewModel
                homePageWindow.Show();
                //close the current main window
                Application.Current.MainWindow.Close();


        }

        public void ExecuteSaveCommand(object? par)
        {

            LostItemsList.Add(new LostItems
            {
                ItemName = newLostItems.ItemName,
                Description = newLostItems.Description,
                DateReported = newLostItems.DateReported,
                Location = newLostItems.Location,
                IsFound = newLostItems.IsFound
            });
            MessageBox.Show("Success", "New Record Added", MessageBoxButton.OK, MessageBoxImage.Information);
            newLostItems.ItemName = string.Empty;
            newLostItems.Description = string.Empty;
            newLostItems.Location = string.Empty;
            newLostItems.DateReported = DateTime.Now;
            newLostItems.IsFound = false;


        }

        public void ExecuteDeleteCommand(object? par)
        {
            LostItemsList.Remove(SelectedLostItems);
        }

        public void ExecuteClearCommand(object? par)
        {
            newLostItems.ItemName = string.Empty;
            newLostItems.Description = string.Empty;
            newLostItems.Location = string.Empty;
            newLostItems.DateReported = DateTime.Now;
            newLostItems.IsFound = false;
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

        

        
       

        public void ExecuteViewFoundItems(object? par)
        {
            MessageBox.Show("This feature is coming soon!", "Coming Soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
