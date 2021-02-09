﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsHomework
{
    public class Node<T> : ICollection<T>
    {
        private Node<T>? _next;
        private T? _data;
        public bool IsReadOnly { get; }

        public int Count
        {
            get
            {
                return Size();
            }
        }


        public Node<T> Next
        {
            get
            {
                return _next!;
            }

            private set
            {
                value._next = this._next;
                _next = value ?? throw new ArgumentNullException();
            }
        }

        public Node(T t)
        {
            Next = this;
            Data = t;
        }


        private void SetNext(Node<T> value)
        {
            _next = value ?? throw new ArgumentNullException();
        }

        public T Data
        {
            get
            {
                return _data!;
            }

            private set
            {
                _data = value ?? throw new ArgumentNullException(nameof(value)); ;
            }
        }

        private int Size() 
        {
            Node<T> cur = this.Next;
            int count = 1;
            while(cur != this)
                {
                    count++;
                    cur = cur.Next;
                }
            return count;
        }

        // int ICollection<T>.Count => throw new NotImplementedException();

        public override string? ToString()
        {
            if (_data is null)
            {
                throw new ArgumentNullException(nameof(_data));
            }

            return _data.ToString();
        }

        public Node<T> Insert(T t)
        {
            Node<T> newNode = new(t);
            this.Next = newNode;

            return newNode;
        }

        // Must dereference all removed nodes by setting them to null to allow for garbage collection
        public void Clear()
        {
            Node<T> cur;

            if (this.Next != this)
            {
                cur = this.Next;
                this.Next = this;
                cur.Clear();
            }
        }

        public void Add(T item)
        {
            Insert(item);
        }

        public bool Contains(T item)
        {
            Node<T> cur = this;
            bool first = true;
            while (cur != this || first)
            {
                if ((cur.Data == null && item == null) || (cur.Data != null && cur.Data.Equals(item)))
                {
                    return true;
                }
                cur = cur.Next;
                first = false;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException("The CopyTo start array index cannot be negative or above the highest index of the target array.");

            Node<T> cur = this;
            bool first = true;
        
            while (cur != this || first)
            {

                if (arrayIndex > array.Length - 1)
                    throw new ArgumentException("The destination array does not have enough space to copy all the elements from the node list.");

                array[arrayIndex] = cur.Data;

                arrayIndex++;
                cur = cur.Next;
                first = false;
            }

        }

        public bool Remove(T item)
        {

            Node<T> prev = this;
            Node<T> cur = this.Next;
            bool first = true;

            while (cur != this.Next || first)
            {
                if ((cur.Data == null && item == null) || (cur.Data != null && cur.Data.Equals(item)))
                {
                    prev.SetNext(cur.Next);// Next set -> cur.next = prev.next
                    return true;
                }
                else
                {
                    prev = cur;
                    cur = cur.Next;
                }
                first = false;
            }
            return false; 
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> cur = this;

            yield return cur.Data;
            for (cur = this.Next; cur != this; cur = cur.Next)
            {
                yield return cur.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
