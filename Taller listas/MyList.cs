using System;
using System.Collections.Generic;

namespace TallerListas
{
    class MyList<T> where T : IComparable<T>
    {
        private Node<T>? head;
        private Node<T>? tail;

        public MyList()
        {
            head = null;
            tail = null;
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if (head == null)
            {
                head = tail = newNode;
                return;
            }

            if (value.CompareTo(head.data) <= 0)
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
                return;
            }

            if (value.CompareTo(tail!.data) >= 0)
            {
                tail.next = newNode;
                newNode.prev = tail;
                tail = newNode;
                return;
            }

            Node<T>? current = head;
            while (current != null)
            {
                if (value.CompareTo(current.data) <= 0)
                {
                    newNode.prev = current.prev;
                    newNode.next = current;
                    current.prev!.next = newNode;
                    current.prev = newNode;
                    return;
                }
                current = current.next;
            }
        }

        public void ShowForward()
        {
            if (head == null) { Console.WriteLine("List is empty."); return; }
            Node<T>? current = head;
            while (current != null)
            {
                Console.Write(current.data + (current.next != null ? " -> " : ""));
                current = current.next;
            }
            Console.WriteLine();
        }

        public void ShowBackward()
        {
            if (tail == null) { Console.WriteLine("List is empty."); return; }
            Node<T>? current = tail;
            while (current != null)
            {
                Console.Write(current.data + (current.prev != null ? " -> " : ""));
                current = current.prev;
            }
            Console.WriteLine();
        }

        public void SortDescending()
        {
            if (head == null || head.next == null) return;
            bool swapped;
            do
            {
                swapped = false;
                Node<T>? current = head;
                while (current != null && current.next != null)
                {
                    if (current.data.CompareTo(current.next.data) < 0)
                    {
                        T temp = current.data;
                        current.data = current.next.data;
                        current.next.data = temp;
                        swapped = true;
                    }
                    current = current.next;
                }
            } while (swapped);
            Console.WriteLine("List sorted in descending order.");
        }

        public void ShowMode()
        {
            if (head == null) { Console.WriteLine("List is empty."); return; }
            var freq = GetFrequencies();
            int max = 0;
            foreach (int count in freq.Values) if (count > max) max = count;

            Console.Write("Mode(s): ");
            bool first = true;
            foreach (var pair in freq)
            {
                if (pair.Value == max)
                {
                    if (!first) Console.Write(", ");
                    Console.Write(pair.Key);
                    first = false;
                }
            }
            Console.WriteLine();
        }

        public void ShowGraph()
        {
            if (head == null) { Console.WriteLine("List is empty."); return; }
            var freq = GetFrequencies();
            Console.WriteLine("Frequency graph:");
            foreach (var pair in freq)
            {
                Console.WriteLine($"{pair.Key}: {new string('*', pair.Value)}");
            }
        }

        private Dictionary<T, int> GetFrequencies()
        {
            var freq = new Dictionary<T, int>();
            Node<T>? current = head;
            while (current != null)
            {
                if (freq.ContainsKey(current.data)) freq[current.data]++;
                else freq[current.data] = 1;
                current = current.next;
            }
            return freq;
        }

        public bool Exists(T value)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.data.CompareTo(value) == 0) return true;
                current = current.next;
            }
            return false;
        }

        public void RemoveOne(T value)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.data.CompareTo(value) == 0)
                {
                    UnlinkNode(current);
                    Console.WriteLine("One occurrence removed.");
                    return;
                }
                current = current.next;
            }
            Console.WriteLine("Value not found.");
        }

        public void RemoveAll(T value)
        {
            bool anyRemoved = false;
            Node<T>? current = head;
            while (current != null)
            {
                Node<T>? nextNode = current.next;
                if (current.data.CompareTo(value) == 0)
                {
                    UnlinkNode(current);
                    anyRemoved = true;
                }
                current = nextNode;
            }
            Console.WriteLine(anyRemoved ? "All occurrences removed." : "Value not found.");
        }

        private void UnlinkNode(Node<T> node)
        {
            if (node == head) head = node.next;
            if (node == tail) tail = node.prev;
            if (node.next != null) node.next.prev = node.prev;
            if (node.prev != null) node.prev.next = node.next;
        }
    }
}
