using MVVM_Project1.Model;
using MVVM_Project1.Model;
using MVVM_Project1.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Project1.ViewModel
{
    class AddLostItemsViewModel: ObservableObject
    {
        private ObservableCollection<LostItems> _sharedList;

        public LostItems NewLostItem { get; set; }
        public ICommand SaveCommand { get; set; }


        public AddLostItemsViewModel(ObservableCollection<LostItems> lostItemsList)
        {
            _sharedList = lostItemsList;
            NewLostItem = new LostItems();
            SaveCommand = new RelayCommand(ExecuteAddNewLostItem);

        }

     
        private void ExecuteAddNewLostItem(object? obj)
        {
            //create logic for adding new lost item to the list
            if (string.IsNullOrWhiteSpace(NewLostItem.ItemName) || string.IsNullOrWhiteSpace(NewLostItem.Description))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                _sharedList.Add(new LostItems
                {
                    ItemName = NewLostItem.ItemName,
                    Description = NewLostItem.Description,
                  //  Location = NewLostItem.Location
                });
                MessageBox.Show("Lost item added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Clear the input fields after adding the item
                //NewLostItem.ItemName = string.Empty;
                //NewLostItem.Description = string.Empty;
                //NewLostItem.Location = string.Empty;

                //make it return to the home page after adding the item
                //var homePageWindow = new HomePage();
                //homePageWindow.Show();
                // 2. Catch the window and close it!AddLostItemsViewModel



                if (obj is Window window)
                {
                    window.Close();
                }


                

            }

        }
    }
}
