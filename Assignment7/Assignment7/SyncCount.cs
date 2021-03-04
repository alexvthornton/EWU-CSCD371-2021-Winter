using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Assignment7
{
    public class Program
    {
        static int _Total = int.MaxValue;
        static int _Count;
        static int _CountLock;
        static int _CountInterlocked;
        static readonly object Locker = new ();
        static readonly ThreadLocal<int> _CountThreadLocal = new ();

        public static int CountUnsynchronized(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }
            _Count = 0;
            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementUnsynchronized());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                _Count++;
            }

            task.Wait();
            Console.WriteLine($"Count = {_Count}");

            return _Count;
        }

        static void DecrementUnsynchronized()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                _Count--;
            }
        }

        public static int CountLock(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }
            _CountLock = 0;
            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementLock());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                lock (Locker)
                {
                    _CountLock++;
                }
            }

            task.Wait();
            Console.WriteLine($"Count = {_Count}");

            return _CountLock;
        }

        static void DecrementLock()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                lock (Locker)
                {
                    _CountLock--;
                }
            }
        }

        public static int CountInterlocked(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }
            _CountInterlocked = 0;
            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementInterlocked());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                Interlocked.Increment(ref _CountInterlocked);
            }

            task.Wait();
            Console.WriteLine($"Count = {_CountInterlocked}");

            return _CountInterlocked;
        }

        static void DecrementInterlocked()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                Interlocked.Decrement(ref _CountInterlocked);
            }
        }

        public static int CountThreadLocal(string[] args)
        {
            if (args?.Length > 0) { int.TryParse(args[0], out _Total); }
            _CountThreadLocal.Value = 0;
            Console.WriteLine($"Increment and decrementing {_Total} times...");

            // Use Task.Factory.StartNew for .NET 4.0
            Task task = Task.Run(() => DecrementThreadLocal());

            // Increment
            for (int i = 0; (i < _Total); i++)
            {
                _CountThreadLocal.Value++;
            }

            task.Wait();
            Console.WriteLine($"Count = {_CountThreadLocal}");

            return _CountThreadLocal.Value;
        }

        static void DecrementThreadLocal()
        {
            // Decrement
            for (int i = 0; i < _Total; i++)
            {
                _CountThreadLocal.Value--;
            }
        }
    }
}
