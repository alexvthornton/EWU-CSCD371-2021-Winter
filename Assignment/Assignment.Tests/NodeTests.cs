using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void GetEnumerator_Count_IteratesThroughCount()
        {
            Node<string> list = CreateSampleStringNodes("First", "Second", "Third", "Fourth");

            Assert.AreEqual<int>(4, list.Count());
        }

        public Node<string> CreateSampleStringNodes(params string[] array)
        {
            Node<string> list = new Node<string>(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                list.Add(array[i]);
            }
            return list;
        }
    
        [TestMethod]
        public void ChildItems_Index3_Given4StringNodes_EqualsToExpectedString()
        {
            Node<string> list = CreateSampleStringNodes("First", "Second", "Third", "Fourth"); 
            IEnumerable<string> childItems = list.ChildItems(3);
            Assert.AreEqual<string>("First, Second, Third", childItems.Aggregate((result, item) => result + ", " + item));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChildItems_GivenIndex5_4StringNodes_ThrowsArgumentOutOfRangeExecption()
        {
            Node<string> list = CreateSampleStringNodes("First", "Second", "Third", "Fourth"); 
            IEnumerable<string> childItems = list.ChildItems(6);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChildItems_GivenIndexNegative_4StringNodes_ThrowsArgumentOutOfRangeExecption()
        {
            Node<string> list = CreateSampleStringNodes("First", "Second", "Third", "Fourth"); 
            IEnumerable<string> childItems = list.ChildItems(-1);
        }
    }

}
