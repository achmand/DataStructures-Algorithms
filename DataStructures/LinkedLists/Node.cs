namespace DataStructures.LinkedLists
{
    public class Node<T> 
    {
        public Node<T> Next { get; set; }
        public Node<T> Prev { get; set; }
        public T Element { get; set; }

        public Node()
        {

        }

        public Node(Node<T> next, T element)
        {
            Next = next;
            Element = element;
        }

        public Node(Node<T> next, Node<T> prev, T element)
        {
            Next = next;
            Prev = prev;
            Element = element;
        }
    }
}
