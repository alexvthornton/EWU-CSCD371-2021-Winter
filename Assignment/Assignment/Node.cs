using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment
{
    public class Node<T> : IEnumerable<T>
    {
        private Node<T> _Next;
        private T _Data;

        public T Data
        {
            get
            {
                return _Data;
            }
            private set
            {
                _Data = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Node<T> Next
        {
            get
            {
                return _Next;
            }

            private set
            {
                value._Next = _Next;
                _Next = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Node(T data)
        {
            _Next = this;
            _Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        private int Size()
        {
            Node<T> current = this.Next;
            int count = 1;
            while (current != this)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public Node<T> Insert(T data)
        {
            Node<T> newNode = new(data);
            this.Next = newNode;

            return newNode;
        }

        public Node<T> Add(T item)
        {
            Node<T> newNode = new(item);
            Node<T> currentNode = this;
            bool first = true;
            while (currentNode.Next != this || first)
            {
                currentNode = currentNode.Next;
                first = false;
            }

            currentNode.Next = newNode;
            return newNode;
        }

        public override string? ToString() => Data!.ToString();

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this;

            yield return current.Data;
            for (current = this.Next; current != this; current = current.Next)
            {
                yield return current.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
        public IEnumerable<T> ChildItems(int maximum)
        {
            if (maximum > Size() || maximum < 0)
                throw new ArgumentOutOfRangeException(nameof(maximum));
            return GetChildItems();
            IEnumerable<T> GetChildItems()
            {
                Node<T> currentNode = this;
                for (int i =0; i < maximum; currentNode = currentNode.Next, i++)
                {
                    yield return currentNode.Data;
                }
            }
        }
    }
}
