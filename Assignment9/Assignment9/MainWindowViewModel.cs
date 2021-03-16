using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment9
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Contact> Contacts { get; } = new ();

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get => _selectedContact;
            set => SetProperty(ref _selectedContact, value);
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

        }

    }


    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string TwitterName { get; set; }
        public DateTime LastModified { get; set; }
    }

}
