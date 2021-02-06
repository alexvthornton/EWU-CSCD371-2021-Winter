﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsHomework
{
    public class Node<T> : ICollection<T>
    {
        private Node<T>? _next;
        private T? _data;

        public Node<T> Next
        {
            get 
            {
                return _next!; 
            }

            private set
            {
                value._next = this._next;
                _next = value??throw new ArgumentNullException();
            }
        }

         public T Data 
        { 
            get 
            {
                return _data!;
            }

            private set
            {
                _data = value??throw new ArgumentNullException();;
            }
        }

        public Node(T t)
        {
            _next = this;
            _data = t;
        }

       

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public override string? ToString()
        {

            if(_data is null)
            {
                throw new ArgumentNullException(nameof(_data));
            }

            return _data.ToString();
        }

        public Node<T> Insert(T t){
            Node<T> newNode = new (t);
            this.Next = newNode;

            return newNode;
        }
        
        // Must deference all removed nodes by setting them to null to allow for garbage collection
        public void Clear()
        {
            Node<T> cur;

            if(this.Next != this)
            {
                cur = this.Next;
                this.Next = this;
                cur.Clear();
            }
        // Node<T>? prev = this;
        // Node<T>? cur = this.Next;
        // while (prev != cur?.Next && cur != this )
        // {
        //     prev = cur?.Next;
        //     cur = null;
        //     cur = prev;
        //     prev = prev?.Next;
        // }
        // prev = null;
        // this.Next = this;
        }

        public void Add(T item)
        {
            Insert(item);
        }

        public bool Contains(T item)
        {

            Node<T> cur = this;
            bool contains = false;
            bool first = true;

            while(cur != this && !first){

                if((cur.Data == null && item == null) || (cur.Data != null && cur.Data.Equals(item)))
                {
                    contains = true;
                }
                cur = cur.Next;
                first = false;
            }

            return contains;
            
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
           throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");

            Node<T> cur = this;
            bool first = true;

            while(cur != this && !first){

                if(arrayIndex > array.Length-1)
                    throw new ArgumentException("The destination array has fewer elements than the collection.");
                
                array[arrayIndex] = cur.Data;

                arrayIndex++;
                first = false;
            }

        }

        public bool Remove(T item)
        {
            Node<T> cur = this.Next;
            Node<T> prev = this;
            bool first = true;

            while(cur != this.Next && !first)
            {
                if((cur.Data == null && item == null) || (cur.Data != null && cur.Data.Equals(item)))
                {
                    prev = cur.Next;
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
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
