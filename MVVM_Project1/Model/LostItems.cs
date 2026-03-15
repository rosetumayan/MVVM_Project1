using MVVM_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Project1.Model
{
    internal class LostItems : ObservableObject
    {
        private string _itemName = string.Empty;
        private string _description = string.Empty;
        private string _location = string.Empty;
        private DateTime _dateReported = DateTime.Now;
        //private DateTime _dateReceived = DateTime.Now;
        private bool _isFound = false;


        


        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (_itemName != value)
                {
                    _itemName = value;
                    OnPropertyChanged(nameof(ItemName));
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string Location
        {
            get { return _location; }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged(nameof(Location));
                }
            }
        }

        public DateTime DateReported
        {
            get { return _dateReported; }
            set
            {
                if (_dateReported != value)
                {
                    _dateReported = value;
                    OnPropertyChanged(nameof(DateReported));
                }
            }
        }

        public bool IsFound { 
            get { return _isFound; }
            set
            {
                if (_isFound != value)
                {
                    _isFound = value;
                    OnPropertyChanged(nameof(IsFound));
                }
            }
        }

    }
}
