using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsHomework.Tests
{

    [TestClass]
    public class NodeTests
    {

        public string ToString(int[] array) => "{" + string.Join(", ", array) + "}";
        public string ToString(ArrayList list) => "{" + string.Join(", ", list.ToArray()) + "}";
        public string ToString<T>(List<T> list) => "{" + string.Join(", ", list.ToArray()) + "}";


        public Node<int> CreateInt4NodeList(int num1, int num2, int num3, int num4)
        {
            Node<int> node1 = new Node<int>(num1);
            Node<int> node2 = node1.Insert(num2);
            Node<int> node3 = node2.Insert(num3);
            Node<int> node4 = node3.Insert(num4);
            return node1;
        }

        public Node<string> CreateString4NodeList(string string1, string string2, string string3, string string4)
        {
            Node<string> node1 = new Node<string>(string1);
            Node<string> node2 = node1.Insert(string2);
            Node<string> node3 = node2.Insert(string3);
            Node<string> node4 = node3.Insert(string4);
            return node1;
        }

        public Node<int[]> CreateIntArray4NodeList(int[] intArr1, int[] intArr2, int[] intArr3, int[] intArr4)
        {
            Node<int[]> node1 = new Node<int[]>(intArr1);
            Node<int[]> node2 = node1.Insert(intArr2);
            Node<int[]> node3 = node2.Insert(intArr3);
            Node<int[]> node4 = node3.Insert(intArr4);
            return node1;
        }

        [TestMethod]
        public void NewInstance_GivenInt_NodeContainsInt()
        {
            Node<int> node1 = new(789);

            Assert.AreEqual("789", node1.Data.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewInstance_GivenNullValue_ThrowArgumentNullException()
        {
            Node<string> node1 = new(null!);
        }

        [TestMethod]
        public void Add_Given4StringNodes_EqualToExpectedString()
        {
            Node<string> list = new("First");
            list.Add("Second");
            list.Add("Third");
            list.Add("Fourth");
            string actual = $"{list.ToString()} {list.Next.ToString()} {list.Next.Next.ToString()} {list.Next.Next.Next.ToString()} {list.Next.Next.Next.Next.ToString()}"; 
            Assert.AreEqual<string>("First Second Third Fourth First", actual);
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
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNodes()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            Assert.AreEqual<string>("Third", node3.Next.Next.ToString()!);
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNode1NextReference()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            Assert.AreEqual<string>("First", node1.Next.Next.ToString()!);
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNode2NextReference()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            Assert.AreEqual<string>("Second", node2.Next.Next.ToString()!);
        }

        [TestMethod]
        public void Clear_Given4StringNodesClearFromNode3_DeferencedNode4NextReference()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            node3.Clear();
            Assert.AreEqual<string>("Fourth", node4.Next.Next.ToString()!);
        }

        [TestMethod]
        public void Contains_Given4IntValues_True()
        {
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);

            Assert.IsTrue(list.Contains(4));
        }

        [TestMethod]
        public void Contains_Given4IntValues_ContainsFirstIndex_True()
        {
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);

            Assert.IsTrue(list.Contains(1));
        }

        [TestMethod]
        public void Contains_Given4IntValues_ContainsNonStoredValue_False()
        {
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);

            Assert.IsFalse(list.Contains(89));
        }

        [TestMethod]
        public void Contains_Given4IntArray_NodesListCreatedFromSingleInstance_True()
        {
            int [] intArr1 = {1 ,2 ,3 ,4};
            int [] intArr2 = {5, 6, 7, 8};
            int [] intArr3 = {9, 10, 11, 12};
            int [] intArr4 = {13, 14, 15, 16};
            Node<int[]> list = CreateIntArray4NodeList(intArr1, intArr2, intArr3, intArr4);

            Assert.IsTrue(list.Contains(intArr2));
        }

        [TestMethod]
        public void CopyTo_GivenInt4Values_CopyTo8LengthArrayAtIndex0_HasCopiedEqualToString()
        {
            int[] copiedArr = new int[4];
            int[] expectedArr = {1, 2, 3, 4};
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            list.CopyTo(copiedArr, 0); 
            Assert.AreEqual<string>(ToString(expectedArr), ToString(copiedArr));
        }

        [TestMethod]
        public void CopyTo_GivenInt4Nodes_CopyTo8LengthArrayAtIndex2_HasCopiedEqualToString()
        {
            int[] copiedArr = new int[8];
            int[] expectedArr = {0, 0, 1, 2, 3, 4, 0, 0};
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            list.CopyTo(copiedArr, 2); 
            Assert.AreEqual<string>(ToString(expectedArr), ToString(copiedArr));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyTo_Given4IntNodes_CopyTo8LengthArrayAtIndex5_ThrowsArgumentException()
        {
            int[] copiedArr = new int[8];
            int[] expectedArr = {0, 0, 1, 2, 3, 4, 0, 0};
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            list.CopyTo(copiedArr, 5); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_Given4IntNodes_CopyTo8LengthArrayAtNegativeIndex_ThrowsArgumentOutOfRangeException()
        {
            int[] copiedArr = new int[8];
            int[] expectedArr = {0, 0, 1, 2, 3, 4, 0, 0};
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            list.CopyTo(copiedArr, -3); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyTo_Given4IntNodes_CopyTo8LengthArrayAtIndex9_ThrowsArgumentOutOfRangeException()
        {
            int[] copiedArr = new int[8];
            int[] expectedArr = {0, 0, 1, 2, 3, 4, 0, 0};
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            list.CopyTo(copiedArr, 9); 
        }

        [TestMethod]
        public void Count_FourNodes_EqualToFour()
        {
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);

            Assert.AreEqual<int>(4, list.Count);
        }

        [TestMethod]
        public void EqualsOperator_GivenIntNode_EqualsIsTrue()
        {
            Node<int> node1 = new Node<int>(789);
            Node<int> node2 = node1;

            Assert.IsTrue(node1 == node2);
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
            Assert.AreEqual<string>("{First, Second, Third, Fourth}", ToString(arrayList));
        }

        [TestMethod]
        public void Insert_Insert4IntNodesFromSingleInstance_InstantiatedContainsNums()
        {
            Node<int> list = new Node<int>(1);
            list = list.Insert(2);
            list = list.Insert(3);
            list = list.Insert(4);

            Assert.AreEqual<string>("1 2 3 4", $"{list.Next.ToString()} {list.Next.Next.ToString()} {list.Next.Next.Next.ToString()} {list.Next.Next.Next.Next.ToString()}");
        }

        [TestMethod]
        public void Insert_Given4StringNodes_EqualToExpectedString()
        {
            Node<string> node1 = new Node<string>("First");
            Node<string> node2 = node1.Insert("Second");
            Node<string> node3 = node2.Insert("Third");
            Node<string> node4 = node3.Insert("Fourth");
            string actual = $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()} {node1.Next.Next.Next.ToString()} {node1.Next.Next.Next.Next.ToString()}"; 
            Assert.AreEqual<string>("First Second Third Fourth First", actual);
        }

        [TestMethod]
        public void Insert_Given4IntNodes_EqualToExpectedString()
        {
            Node<int> node1 = new Node<int>(10);
            Node<int> node2 = node1.Insert(33);
            Node<int> node3 = node2.Insert(42);
            Node<int> node4 = node3.Insert(86);

            Assert.AreEqual<string>("10 33 42 86", $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()} {node1.Next.Next.Next.ToString()}");
        }

        [TestMethod]
        public void Insert_Given4IntArrayNodes_EqualToExpectedString()
        {
            int [] intArr1 = {1 ,2 ,3 ,4};
            int [] intArr2 = {5, 6, 7, 8};
            int [] intArr3 = {9, 10, 11, 12};
            int [] intArr4 = {13, 14, 15, 16};
            Node<int[]> node1 = new Node<int[]>(intArr1);
            Node<int[]> node2 = node1.Insert(intArr2);
            Node<int[]> node3 = node2.Insert(intArr3);
            Node<int[]> node4 = node3.Insert(intArr4);
            Assert.IsTrue(node1.Contains(intArr2));
        }

        [TestMethod]
        public void IsReadOnly_Given4IntNodes_False()
        {
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            Assert.IsFalse(list.IsReadOnly);
        }

        [TestMethod]
        public void Remove_Given4IntNodesRemoveFirstNode_TrueRemoved()
        {
            Node<int> list = CreateInt4NodeList(1, 2, 3, 4);
            Assert.IsTrue(list.Remove(1));
        }

        [TestMethod]
        public void Remove_Given4IntNodesRemoveSecondNode_TrueRemoved()
        {
            Node<int> node1 = new Node<int>(10);
            Node<int> node2 = node1.Insert(33);
            Node<int> node3 = node2.Insert(42);
            Node<int> node4 = node3.Insert(86);
            node1.Remove(33);
            Assert.AreEqual<string>("10 42 86 10", $"{node1.ToString()} {node1.Next.ToString()} {node1.Next.Next.ToString()} {node1.Next.Next.Next.ToString()}");
        }

        [TestMethod]
        public void Remove_Given4StringNodesRemoveFourthNode_TrueRemoved()
        {
            Node<string> list = CreateString4NodeList("First", "Second", "Third", "Fourth");
            Assert.IsTrue(list.Remove("Fourth"));
            Assert.AreEqual<string>("First Second Third First",$"{list.ToString()} {list.Next.ToString()} {list.Next.Next.ToString()} {list.Next.Next.Next.ToString()}"); 
        }

        [TestMethod]
        public void Remove_Given4IntArrayNodes_TrueRemoved()
        {
            int [] intArr1 = {1 ,2 ,3 ,4};
            int [] intArr2 = {5, 6, 7, 8};
            int [] intArr3 = {9, 10, 11, 12};
            int [] intArr4 = {13, 14, 15, 16};
            Node<int[]> list = CreateIntArray4NodeList(intArr1, intArr2, intArr3, intArr4);

            Assert.IsTrue(list.Remove(intArr3));

            string expected = $"{ToString(intArr1)}, {ToString(intArr2)}, {ToString(intArr4)}";
            string actual = $"{ToString(list.Data)}, {ToString(list.Next.Data)}, {ToString(list.Next.Next.Data)}";

            Assert.AreEqual<string>(expected, actual); 
        }

        [TestMethod]
        public void ToString_GivenInt_EqualToString()
        {
            Node<int> node1 = new Node<int>(34);

            Assert.AreEqual<string>("34", node1.ToString()!);
        }

        [TestMethod]
        public void ToString_GivenString_EqualToString()
        {
            Node<string> node1 = new Node<string>("Word");

            Assert.AreEqual<string>("Word", node1.ToString()!);
        }

        [TestMethod]
        public void ToString_Given4IntArrayyNodes_EqualToString()
        {
            int [] intArr1 = {1 ,2 ,3 ,4};
            int [] intArr2 = {5, 6, 7, 8};
            int [] intArr3 = {9, 10, 11, 12};
            int [] intArr4 = {13, 14, 15, 16};
            Node<int[]> list = CreateIntArray4NodeList(intArr1, intArr2, intArr3, intArr4);

            string expected = $"{ToString(intArr1)}, {ToString(intArr2)}, {ToString(intArr3)}, {ToString(intArr4)}";
            string actual = $"{ToString(list.Data)}, {ToString(list.Next.Data)}, {ToString(list.Next.Next.Data)}, {ToString(list.Next.Next.Next.Data)}";

            Assert.AreEqual<string>(expected, actual); 
        }
    }
}
