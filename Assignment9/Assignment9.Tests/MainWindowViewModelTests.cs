using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Assignment9.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void Contacts_ReturnsObservableContactCollection()
        {
            var viewModel = new MainWindowViewModel();

            Assert.AreEqual(typeof(ObservableCollection<Contact>), viewModel.Contacts.GetType());
        }

        [TestMethod]
        public void EditGet_IntializedToFalse()
        {
            var viewModel = new MainWindowViewModel();

            Assert.IsFalse(viewModel.Edit);
        }

        [TestMethod]
        public void  SelectedContact_IntializedToNull()
        {
            var viewModel = new MainWindowViewModel();

            Assert.IsNull(viewModel.SelectedContact);
        }

        [TestMethod]
        public void SelectedContactGet_ReturnsContact()
        {
            var viewModel = new MainWindowViewModel();

            viewModel.SelectedContact = new();

            Assert.AreEqual(typeof(Contact), viewModel.SelectedContact.GetType());
        }

        [TestMethod]
        public void SetProperty_DoesSetProperty()
        {
            var viewModel = new MainWindowViewModel();
            viewModel.Edit = true;

            Assert.IsTrue(viewModel.Edit);
        } 
        [TestMethod]
        public void EditCommand_ReturnsRelayCommand()
        {
            var viewModel = new MainWindowViewModel();
            Assert.AreEqual(typeof(RelayCommand), viewModel.EditCommand.GetType());
        }

        [TestMethod]
        public void EditCommand_NotNull()
        {
            var viewModel = new MainWindowViewModel();
            Assert.IsNotNull(viewModel.EditCommand);
        }

        [TestMethod]
        public void EditCommand_True_False()
        {
            var viewModel = new MainWindowViewModel();
            viewModel.Edit = true;
            var editCommand = viewModel.EditCommand;

            editCommand.Execute(null);

            Assert.IsFalse(viewModel.Edit);
        }

        [TestMethod]
        public void EditCommand_False_True()
        {
            var viewModel = new MainWindowViewModel();
            viewModel.Edit = false;
            var editCommand = viewModel.EditCommand;

            editCommand.Execute(null);

            Assert.IsTrue(viewModel.Edit);
        }

        [TestMethod]
        public void NewContactCommand_ReturnsRelayCommand()
        {
            var viewModel = new MainWindowViewModel();
            Assert.AreEqual(typeof(RelayCommand), viewModel.NewContactCommand.GetType());
        }

        [TestMethod]
        public void NewContactCommand_NotNull()
        {
            var viewModel = new MainWindowViewModel();
            Assert.IsNotNull(viewModel.NewContactCommand);
        }

        [TestMethod]
        public void NewContactCommand_AddNewContact_CountIncrease()
        {
            var viewModel = new MainWindowViewModel();
            var initialCount = viewModel.Contacts.Count;
            var newContactCommand = viewModel.NewContactCommand;
            newContactCommand.Execute(null);

            Assert.AreEqual(initialCount+1, viewModel.Contacts.Count);
        }

        [TestMethod]
        public void DeleteContactCommand_ReturnsRelayCommand()
        {
            var viewModel = new MainWindowViewModel();
            Assert.AreEqual(typeof(RelayCommand), viewModel.DeleteContactCommand.GetType());
        }

        [TestMethod]
        public void DeleteContactCommand_NotNull()
        {
            var viewModel = new MainWindowViewModel();
            Assert.IsNotNull(viewModel.DeleteContactCommand);
        }

        [TestMethod]
        public void DeleteContactCommand_DeleteContact_CountDecrease()
        {
            var viewModel = new MainWindowViewModel();
            int initialCount = viewModel.Contacts.Count;
            var deleteContactCommand = viewModel.DeleteContactCommand;
            viewModel.SelectedContact = viewModel.Contacts[0];
            deleteContactCommand.Execute(null);

            Assert.AreEqual(initialCount-1, viewModel.Contacts.Count);
        }
    }
}
