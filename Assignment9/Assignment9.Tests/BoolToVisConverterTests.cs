using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment9.Tests
{
    [TestClass]
    public class BoolToVisConverterTests
    {

        [TestMethod]
        public void Convert_True_Visible()
        {
            var boolToVisConverter = new BoolToVisConverter();

            var result = (Visibility)boolToVisConverter.Convert(true, null, null, null);

            Assert.AreEqual(Visibility.Visible, result);
        }

        [TestMethod]
        public void Convert_False_Collapsed()
        {
            var boolToVisConverter = new BoolToVisConverter();

            var result = (Visibility)boolToVisConverter.Convert(false, null, null, null);

            Assert.AreEqual(Visibility.Collapsed, result);
        }

        [TestMethod]
        public void ConvertBack_Visible_True()
        {
            var boolToVisConverter = new BoolToVisConverter();

            var result = (bool)boolToVisConverter.ConvertBack(Visibility.Visible, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ConvertBack_Collapsed_False()
        {
            var boolToVisConverter = new BoolToVisConverter();

            var result = (bool)boolToVisConverter.ConvertBack(Visibility.Collapsed, null, null, null);

            Assert.IsFalse(result);
        }


    }
}
