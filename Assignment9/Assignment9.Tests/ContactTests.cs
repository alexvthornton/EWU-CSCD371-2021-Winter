using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.Tests
{
    [TestClass]
    public class ContactTests
    {

        [TestMethod]
        public void FirstName_SetNewValue_EqualToNewValue()
        {
           Contact contact = new();             
           contact.FirstName = "James";
           Assert.AreEqual("James", contact.FirstName);
        }

        [TestMethod]
        public void LastName_SetNewValue_EqualToNewValue()
        {
           Contact contact = new();             
           contact.LastName = "Smith";
           Assert.AreEqual("Smith", contact.LastName);
        }

        [TestMethod]
        public void PhoneNumber_SetNewValue_EqualToNewValue()
        {
           Contact contact = new();             
           contact.PhoneNumber = "509-123-1234";
           Assert.AreEqual("509-123-1234", contact.PhoneNumber);
        }

        [TestMethod]
        public void EmailAddress_SetNewValue_EqualToNewValue()
        {
           Contact contact = new();             
           contact.EmailAddress = "email@gmail.com";
           Assert.AreEqual("email@gmail.com", contact.EmailAddress);
        }

        [TestMethod]
        public void TwitterName_SetNewValue_EqualToNewValue()
        {
           Contact contact = new();             
           contact.TwitterName = "username";
           Assert.AreEqual("username", contact.TwitterName);
        }

        [TestMethod]
        public void LastModified_FirstName_TimeChanged()
        {
           Contact contact = new();             
           var initialLastModified = contact.LastModified;
           contact.FirstName = "James";
           Assert.AreNotEqual(initialLastModified, contact.LastModified);
        }
        
        [TestMethod]
        public void LastModified_IsTypeOfDateTime()
        {
           Contact contact = new();             
           Assert.AreEqual(typeof(DateTime), contact.LastModified.GetType());
        }

        [TestMethod]
        public void LastModified_LastName_TimeChanged()
        {
           Contact contact = new();             
           var initialLastModified = contact.LastModified;
           contact.LastName = "Smith";
           Assert.AreNotEqual(initialLastModified, contact.LastModified);
        }

        [TestMethod]
        public void LastModified_PhoneNumber_TimeChanged()
        {
           Contact contact = new();             
           var initialLastModified = contact.LastModified;
           contact.PhoneNumber = "509-123-1234";
           Assert.AreNotEqual(initialLastModified, contact.LastModified);
        }

        [TestMethod]
        public void LastModified_EmailAddress_TimeChanged()
        {
           Contact contact = new();             
           var initialLastModified = contact.LastModified;
           contact.EmailAddress = "email@gmail.com";
           Assert.AreNotEqual(initialLastModified, contact.LastModified);
        }

        [TestMethod]
        public void LastModified_TwitterName_TimeChanged()
        {
           Contact contact = new();             
           var initialLastModified = contact.LastModified;
           contact.TwitterName = "username";
           Assert.AreNotEqual(initialLastModified, contact.LastModified);
        }
    }
}
