﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Assignment9
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand EditCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Contact> Contacts { get; } = new ();

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
        }

        public void ToggleEdit() 
        {
            Edit = !Edit;  
        }
    }

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

    public class Contact : INotifyPropertyChanged
    {
        private string _firstName;
        public string FirstName {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value);
                LastModified = DateTime.Now;
            }
         }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                SetProperty(ref _lastName, value);
                LastModified = DateTime.Now;
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                SetProperty(ref _phoneNumber, value);
                LastModified = DateTime.Now;
            }
        }
        private string _emailAddress;
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                SetProperty(ref _emailAddress, value);
                LastModified = DateTime.Now;
            }
        }

        private string _twitterName;
        public string TwitterName
        {
            get => _twitterName;
            set
            {
                SetProperty(ref _twitterName, value);
                LastModified = DateTime.Now;
            }
        }

        private DateTime _lastModified;
        public DateTime LastModified {
            get => _lastModified;
            set => SetProperty(ref _lastModified, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }

}
