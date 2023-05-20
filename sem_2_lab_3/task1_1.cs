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
        if (item == null)
        {
            throw new ArgumentException("Cannot add a null item into this deque!");
        }
        else
        {
            Node newNode = new Node(item);
            newNode.prev = sentinel;
            newNode.next = sentinel.next;
            sentinel.next.prev = newNode;
            sentinel.next = newNode;
            size++;
        }
    }

    public void AddLast(Item item)
    {
        if (item == null)
        {
            throw new ArgumentException("Cannot add a null item into this deque!");
        }
        else
        {
            Node newNode = new Node(item);
            newNode.next = sentinel;
            newNode.prev = sentinel.prev;
            sentinel.prev.next = newNode;
            sentinel.prev = newNode;
            size++;
        }
    }

    public Item RemoveFirst()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("The deque is empty, nothing to remove.");
        }
        else
        {
            Node firstNode = sentinel.next;
            sentinel.next = firstNode.next;
            firstNode.next.prev = sentinel;
            size--;
            return firstNode.value;
        }
    }

    public Item RemoveLast()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("The deque is empty, nothing to remove.");
        }
        else
        {
            Node lastNode = sentinel.prev;
            sentinel.prev = lastNode.prev;
            lastNode.prev.next = sentinel;
            size--;
            return lastNode.value;
        }
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
        Deque<int> deque = new Deque<int>();
        deque.AddFirst(11);
        deque.AddLast(0);
        deque.AddLast(63);
        deque.RemoveFirst();
        deque.AddLast(5);
        deque.RemoveLast();
        deque.AddFirst(1);
        deque.AddLast(2);
        deque.AddLast(4);

        foreach (int i in deque)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}