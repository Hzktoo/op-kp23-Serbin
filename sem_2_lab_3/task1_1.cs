using System;
using System.Collections;
using System.Collections.Generic;

public class Deque<Item> : IEnumerable<Item>
{
    private Node sentinel;
    private int size;

    private class Node
    {
        public Item value;
        public Node next;
        public Node prev;
        public Node(Item value)
        {
            this.value = value;
        }
    }

    public Deque()
    {
        sentinel = new Node(default);
        sentinel.next = sentinel;
        sentinel.prev = sentinel;
        size = 0;
    }

    public bool IsEmpty => size == 0;
    public int Size => size;

    public void AddFirst(Item item)
    {
        // add the item to the front
    }

    public void AddLast(Item item)
    {
        // add the item to the end
    }

    public Item RemoveFirst()
    {
        // remove and return the item from the front
        Node firstNode = sentinel.next;
            return firstNode.value;
    }

    public Item RemoveLast()
    {
        // remove and return the item from the end
        Node lastNode = sentinel.prev;
            
            return lastNode.value;
        
    }

    public IEnumerator<Item> GetEnumerator()
    {
        Node currentNode = sentinel.next;

        while (currentNode != sentinel)
        {
            yield return currentNode.value;
            currentNode = currentNode.next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


}
class Program
{
    static void Main(string[] args)
    {
        // unit testing (required)
        /*
         input: 11 23 42 1 3
         RemoveFirst; RemoveLast
         output: 23 42 1
         */
    }
}