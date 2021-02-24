using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsHomework.Tests
{

    [TestClass]
    public class NodeIEnumerableTests
    {

        public Node<string> CreateString4NodeList(string string1, string string2, string string3, string string4)
        {
            Node<string> node1 = new Node<string>(string1);
            Node<string> node2 = node1.Insert(string2);
            Node<string> node3 = node2.Insert(string3);
            Node<string> node4 = node3.Insert(string4);
            return node1;
        }

        [TestMethod]
        public void ChildItems_Index3_Given4StringNodes_EqualsToExpectedString()
        {
            string actual = "";
            Node<string> list = CreateString4NodeList("First", "Second", "Third", "Fourth"); 
            IEnumerable<string> childItems = list.ChildItems(3);
            foreach (string item in childItems)
                actual+=item+" ";
            Assert.AreEqual<string>("First Second Third ", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChildItems_GivenIndex5_4StringNodes_ThrowsArgumentOutOfRangeExecption()
        {
            Node<string> list = CreateString4NodeList("First", "Second", "Third", "Fourth"); 
            IEnumerable<string> childItems = list.ChildItems(6);
            string actual = "";
            foreach (string item in childItems)
                actual+=item+" ";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChildItems_GivenIndexNegative_4StringNodes_ThrowsArgumentOutOfRangeExecption()
        {
            Node<string> list = CreateString4NodeList("First", "Second", "Third", "Fourth"); 
            IEnumerable<string> childItems = list.ChildItems(-1);
            string actual = "";
            foreach (string item in childItems)
                actual+=item+" ";
        }

        [TestMethod]
        public void GetEnumerator_ForeachAddToArrayList_Given4StringValues_EqualToString()
        {
            Node<string> list = CreateString4NodeList("First", "Second", "Third", "Fourth");

            ArrayList arrayList = new();
            foreach (string item in list)
            {
                arrayList.Add(item);
            }
            Assert.AreEqual<string>("First, Second, Third, Fourth", string.Join(", ",arrayList.ToArray()));
        }

    }

}
