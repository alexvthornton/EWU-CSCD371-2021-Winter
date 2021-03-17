using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment9
{
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
