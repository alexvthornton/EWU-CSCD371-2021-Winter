using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.Tests
{
    [TestClass]
    public class BoolToEditSaveTests
    {
        [TestMethod]
        public void Convert_True_Save()
        {
            var boolToEditSave = new BoolToEditSave();

            var result = (string)boolToEditSave.Convert(true, null, null, null);

            Assert.AreEqual("Save", result);
        }

        [TestMethod]
        public void Convert_False_Edit()
        {
            var boolToEditSave = new BoolToEditSave();

            var result = (string)boolToEditSave.Convert(false, null, null, null);

            Assert.AreEqual("Edit", result);
        }

        [TestMethod]
        public void ConvertBack_Save_True()
        {
            var boolToEditSave = new BoolToEditSave();

            var result = (bool)boolToEditSave.ConvertBack("Save", null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ConvertBack_Edit_False()
        {
            var boolToEditSave = new BoolToEditSave();

            var result = (bool)boolToEditSave.ConvertBack("Edit", null, null, null);

            Assert.IsFalse(result);
        }


    }
}
