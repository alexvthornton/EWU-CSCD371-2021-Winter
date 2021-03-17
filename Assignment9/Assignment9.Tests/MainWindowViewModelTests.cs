using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Assignment9.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void EditCommand_ReturnsRelayCommand()
        {
            var vm = new MainWindowViewModel();
            Assert.AreEqual(typeof(RelayCommand), vm.EditCommand.GetType());
        }

        [TestMethod]
        public void EditCommand_NotNull()
        {
            var vm = new MainWindowViewModel();
            Assert.IsNotNull(vm.EditCommand);
        }

        [TestMethod]
        public void EditCommand_True_False()
        {
            var vm = new MainWindowViewModel();
            vm.Edit = true;
            var editCommand = vm.EditCommand;

            editCommand.Execute(null);

            Assert.IsFalse(vm.Edit);
        }

        [TestMethod]
        public void EditCommand_False_True()
        {
            var vm = new MainWindowViewModel();
            vm.Edit = false;
            var editCommand = vm.EditCommand;

            editCommand.Execute(null);

            Assert.IsTrue(vm.Edit);
        }


        [TestMethod]
        public void Contacts_returnsContactList()
        {
            var vm = new MainWindowViewModel();

            Assert.AreEqual(typeof(List<Contact>), vm.Contacts.GetType());
        }

        [TestMethod]
        public void EditGet_IntializedToFalse()
        {
            var vm = new MainWindowViewModel();

            Assert.IsFalse(vm.Edit);
        }

        [TestMethod]
        public void  SelectedContact_IntializedToNull()
        {
            var vm = new MainWindowViewModel();

            Assert.IsNull(vm.SelectedContact);
        }

        [TestMethod]
        public void SelectedContactGet_ReturnsContact()
        {
            var vm = new MainWindowViewModel();

            vm.SelectedContact = new();

            Assert.AreEqual(typeof(Contact), vm.SelectedContact.GetType());
        }

        [TestMethod]
        public void SetProperty_doesSetProperty()
        {
            var vm = new MainWindowViewModel();
            vm.Edit = true;

            Assert.IsTrue(vm.Edit);
        } 


    }
}
