using System;
using System.Windows.Input;

namespace MVVM_Project1.ViewModel
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        public RelayCommand(Action<object?> execute) => _execute = execute;

        
        public bool CanExecute(object? parameter) => true;
        public void Execute(object? parameter) => _execute(parameter);

        // This fix removes the CS0067 warning by linking to the WPF CommandManager
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
