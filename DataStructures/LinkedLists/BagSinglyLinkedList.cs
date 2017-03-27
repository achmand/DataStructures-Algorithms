using System.Collections.Generic;

namespace DataStructures.LinkedLists
{
    /*
     * A bag (or multiset) is similiar to a set and stores an unordered group of elements.
     * The main difference is that each element may be stored more than once. 
     * Implement the bag datastructure based on a singly linked list. If an element is repeated,
     * do not repeadtedly store the value multiple times, but instead keep count of hot many times it
     * appears. 
    */

    // we will not be using the prev node as it is a singly linked list 
    public class BagNode<T> : Node<T>
    {
        public int Count { get; set; } // keeps track of how many times the element appears 
    }

    // some errors might be present because the singlyLinkedlist is built using Node<T> not BagNode<T>.
    // if you change the node structure everything will work smoothly.
    public sealed class BagSinglyLinkedList<T> : SinglyLinkedList<T>
    {
        //public int GetCountElement(T element)
        //{
        //    var currNode = Head.Next;
        //    while (currNode != null)
        //    {
        //        if (currNode.Element.Equals(element))
        //        {
        //            return currNode.Count;
        //        }
        //        currNode = currNode.Next;
        //    }
        //    return 0;
        //}

        //public List<T> AlphaCut(int alpha)
        //{
        //    var list = new List<T>();
        //    var currNode = Head.Next;
        //    while (currNode != null)
        //    {
        //        if (currNode.Count == alpha)
        //        {
        //            list.Add(currNode.Element);
        //        }
        //        currNode = currNode.Next;
        //    }

        //    return list;
        //}
    }
}
