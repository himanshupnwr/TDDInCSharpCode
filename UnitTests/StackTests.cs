using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var stack = new MyStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        public void PushOneItem_ReturnsCountOne()
        {
            var stack = new MyStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [TestMethod]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new MyStack<int>();

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                stack.Pop();
            });
        }

        [TestMethod]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.AreEqual(2, stack.Peek());
        }
    }

    public class MyStack<T>
    {
        List<T> myList = new List<T>();
        public bool IsEmpty => Count == 0;
        public int Count => myList.Count;

        public void Push(T item)
        {
            myList.Add(item);
        }

        public void Pop()
        {
            if (myList.Count == 0)
                throw new InvalidOperationException();
        }

        public T Peek()
        {
            return myList[Count - 1];
        }
    }
}
