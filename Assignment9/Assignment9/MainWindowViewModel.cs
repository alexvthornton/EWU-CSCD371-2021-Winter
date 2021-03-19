using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assignment9
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand EditCommand { get; }
        public ICommand NewContactCommand { get; }
        public ICommand DeleteContactCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Contact> Contacts { get; } = new ();

        private bool _edit = false; 
        public bool Edit {
            get => _edit;
            set => SetProperty(ref _edit, value); 
        } 

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                SetProperty(ref _selectedContact, value);
                Edit = false;
            }
        }

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName ="")
        {
            if(!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

        public MainWindowViewModel()
        {
            Contacts.Add(
                new()
                {
                    FirstName = "Jim",
                    LastName = "John",
                    PhoneNumber = "509-431-5309",
                    EmailAddress = "jjohn9@gmail.com",
                    TwitterName = "slimJimJohn",
                    LastModified = DateTime.Now
                });

            Contacts.Add(
                new()
                {
                    FirstName = "Sue",
                    LastName = "May",
                    PhoneNumber = "129-441-5446",
                    EmailAddress = "smay43@gmail.com",
                    TwitterName = "maybsue",
                    LastModified = DateTime.Now
                });

            EditCommand = new RelayCommand(ToggleEdit);
            NewContactCommand = new RelayCommand(CreateNewContact);
            DeleteContactCommand = new RelayCommand(DeleteContact);
        }

        private void ToggleEdit()
        {
            Edit = !Edit;
        }

        private void CreateNewContact()
        {
            Contact newContact = new() { FirstName = "New", LastName = "Contact" };
            Contacts.Add(newContact);
            SelectedContact = newContact;
            Edit = true;
        }

        private void DeleteContact()
        {
            Contacts.Remove(SelectedContact);
        }
    }

}
