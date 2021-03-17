using System;
using System.Windows.Input;

namespace Assignment9
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action ToggleEdit { get; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ToggleEdit.Invoke();
        }

        public RelayCommand(Action toggleEdit)
        {
            ToggleEdit = toggleEdit;

        }
    }

}
