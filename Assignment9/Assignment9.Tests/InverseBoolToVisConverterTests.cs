using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.Tests
{
    [TestClass]
    public class InverseBoolToVisConverterTests
    {
        [TestMethod]
        public void Convert_True_Visible()
        {
            var inverseBoolToVisConverter = new InverseBoolToVisConverter();

            var result = (Visibility)inverseBoolToVisConverter.Convert(true, null, null, null);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void Convert_False_Collapsed()
        {
            var inverseBoolToVisConverter = new InverseBoolToVisConverter();

            var result = (Visibility)inverseBoolToVisConverter.Convert(false, null, null, null);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void ConvertBack_Collapsed_True()
        {
            var inverseBoolToVisConverter = new InverseBoolToVisConverter();

            var result = (bool)inverseBoolToVisConverter.ConvertBack(Visibility.Collapsed, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ConvertBack_Visible_False()
        {
            var inverseBoolToVisConverter = new InverseBoolToVisConverter();

            var result = (bool)inverseBoolToVisConverter.ConvertBack(Visibility.Visible, null, null, null);

            Assert.IsFalse(result);
        }

    }
}
