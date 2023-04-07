using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitTests
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void CreateNode_SetsValueAndNextIsNull()
        {
            LinkedNode<int> node = new LinkedNode<int>(1);

            Assert.AreEqual(1, node.Value);
            Assert.IsNull(node.Next);
        }

        [TestMethod]
        public void AddFirst_HeadAndTailAreSame()
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddFirst(1);

            Assert.AreEqual(1, list.HeadNode.Value);
            Assert.AreEqual(1, list.TailNode.Value);
            Assert.AreSame(list.HeadNode, list.TailNode);
        }

        [TestMethod]
        public void AddFirstTwoElements_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);

            Assert.AreEqual(1, list.TailNode.Value);
            Assert.AreEqual(2, list.HeadNode.Value);
            Assert.AreEqual(2, list.Count);
            Assert.AreSame(list.HeadNode.Next, list.TailNode);
        }

        [TestMethod]
        public void AddLast_HeadAndTailAreSame()
        {
            var list = new MyLinkedList<int>();
            list.AddLast(1);

            Assert.AreEqual(1, list.HeadNode.Value);
            Assert.AreEqual(1, list.TailNode.Value);
            Assert.AreSame(list.HeadNode, list.TailNode);
        }

        [TestMethod]
        public void AddLastTwoElements_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            Assert.AreEqual(1, list.HeadNode.Value);
            Assert.AreEqual(2, list.TailNode.Value);
            Assert.AreEqual(2, list.Count);
            Assert.AreSame(list.HeadNode.Next, list.TailNode);
        }

        [TestMethod]
        public void RemoveFirst_EmptyList_Throws()
        {
            var list = new MyLinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                list.RemoveFirst();
            });
        }

        [TestMethod]
        public void RemoveLast_EmptyList_Throws()
        {
            var list = new MyLinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                list.RemoveLast();
            });
        }

        [TestMethod]
        public void RemoveLast_OneElement_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);

            list.RemoveLast();

            Assert.IsNull(list.HeadNode);
            Assert.IsNull(list.TailNode);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void RemoveLast_TwoElements_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);

            list.RemoveLast();

            Assert.AreEqual(1, list.HeadNode.Value);
            Assert.AreEqual(1, list.Count);
            Assert.AreSame(list.HeadNode, list.TailNode);
        }

        [TestMethod]
        public void RemoveFirst_OneElement_ListIsInCorrectState()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);

            list.RemoveFirst();

            Assert.IsNull(list.HeadNode);
            Assert.IsNull(list.TailNode);
            Assert.AreEqual(0, list.Count);
        }
    }

    public class MyLinkedList<T>
    {
        public LinkedNode<T> HeadNode { get; private set; }
        public LinkedNode<T> TailNode { get; private set; }
        public int Count { get; set; }

        public void AddFirst(T Value)
        {
            AddFirst(new LinkedNode<T>(Value));
        }

        private void AddFirst(LinkedNode<T> node)
        {
            //save off the head node so that we don't loose it
            LinkedNode<T> temp = HeadNode;

            //Point head to the new node
            HeadNode = node;

            //Insert the rest of the list behind the head
            HeadNode.Next = temp;

            Count++;

            if (Count == 1)
            {
                TailNode = HeadNode;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new LinkedNode<T>(value));
        }

        private void AddLast(LinkedNode<T> node)
        {
            if (Count == 0)
            {
                HeadNode = node;
            }
            else
            {
                TailNode.Next = node;
            }

            TailNode = node;

            Count++;
        }

        public void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            HeadNode = HeadNode.Next;

            Count--;

            if (Count == 0)
            {
                TailNode = null;
            }
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            if (Count == 1)
            {
                HeadNode = null;
                TailNode = null;
            }

            else
            {
                //Before: Head --> 3 --> 5 --> 7
                //        Tail = 7
                //After: Head --> 3 -->5 --> null
                //       Tail = 5

                LinkedNode<T> current = HeadNode;
                while (current.Next != TailNode)
                {
                    current = current.Next;
                }
                current.Next = null;
                TailNode = current;
            }

            Count--;
        }
    }

    

    public class LinkedNode<T>
    {
        public LinkedNode<T> Next { get; set; }
        public T Value { get; set; }

        public LinkedNode(T value)
        {
            Value = value;
        }
    }
}
