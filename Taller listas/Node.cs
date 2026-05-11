using System;

namespace TallerListas
{
    // Clase Nodo con referencias anulables
    class Node<T> where T : IComparable<T>
    {
        public T data;
        public Node<T>? next;
        public Node<T>? prev;

        public Node(T value)
        {
            data = value;
            next = null;
            prev = null;
        }
    }
}