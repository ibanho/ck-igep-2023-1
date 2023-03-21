using System.Collections.Generic;
using UnityEngine;

public partial class CSharpDemo : MonoBehaviour
{
    // Declare the generic class.
    //public class GenericList<T>
    //{
    //    public void Add(T input) { }
    //}

    //class TestGenericList
    //{
    //    private class ExampleClass { }
    //    static void Main()
    //    {
    //        // Declare a list of type int.
    //        GenericList<int> list1 = new GenericList<int>();
    //        list1.Add(1);

    //        // Declare a list of type string.
    //        GenericList<string> list2 = new GenericList<string>();
    //        list2.Add("");

    //        // Declare a list of type ExampleClass.
    //        GenericList<ExampleClass> list3 = new GenericList<ExampleClass>();
    //        list3.Add(new ExampleClass());
    //    }
    //}

    // type parameter T in angle brackets
    public class GenericList<T>
    {
        // The nested class is also generic on T.
        private class Node
        {
            // T used in non-generic constructor.
            public Node(T t)
            {
                next = null;
                data = t;
            }

            private Node? next;
            public Node? Next
            {
                get { return next; }
                set { next = value; }
            }

            // T as private member data type.
            private T data;

            // T as return type of property.
            public T Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node? head;

        // constructor
        public GenericList()
        {
            head = null;
        }

        // T as method parameter type:
        public void AddHead(T t)
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    public void  TestGenericList()
    {
        // int is the type argument
        GenericList<int> list = new GenericList<int>();

        for (int x = 0; x < 10; x++)
        {
            list.AddHead(x);
        }

        foreach (int i in list)
        {
            _stringBuilder.Append(i + " ");
        }
        Debug.Log(_stringBuilder.ToString());
        _stringBuilder.Clear();
        Debug.Log("Done");
    }
}
