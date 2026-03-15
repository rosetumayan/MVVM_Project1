using MVVM_Project1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Project1.Model
{
    /// <summary>
    /// This class represents the user model in the MVVM architecture. It contains properties for the username, password, and status message. 
    /// The properties are implemented with change notification to allow the view to update when the values change.
    /// This class inherits from ObservableObject, which provides the OnPropertyChanged method to raise property change notifications.
    /// The private fields store the actual values of the properties, 
    /// and the public properties provide access to these fields while also raising notifications when they are changed.
    /// Thus, this class serves as the data model for user-related information in the application, 
    /// allowing for a clean separation of concerns between the view and the view model.
    /// </summary>
    public class UserModel : ObservableObject
    {
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _statusMessage = string.Empty;

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                if (_statusMessage != value)
                {
                    _statusMessage = value;
                    OnPropertyChanged(nameof(StatusMessage));
                }
            }
        }
    }
}
