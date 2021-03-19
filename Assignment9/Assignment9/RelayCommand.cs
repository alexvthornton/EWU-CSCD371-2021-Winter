using System;
using System.Windows.Input;

namespace Assignment9
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public Action Action { get; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action.Invoke();
        }
        public RelayCommand(Action action)
        {
            Action = action;
        }
    }
}