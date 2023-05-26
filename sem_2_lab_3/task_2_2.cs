using System;
using System.Collections;
using System.Collections.Generic;

public class RandomizedQueue<Item> : IEnumerable<Item>
{
    private Node head;
    private Node tail;
    private int size;
    private Random random;

    private class Node
    {
        public Item value;
        public Node next;

        public Node(Item value)
        {
            this.value = value;
            next = null;
        }
    }

    public RandomizedQueue()
    {
        head = null;
        tail = null;
        size = 0;
        random = new Random();
    }

    public bool IsEmpty => size == 0;
    public int Size => size;

    public void Enqueue(Item item)
    {
        Node newNode = new Node(item);

        if (IsEmpty)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }

        size++;
    }

    public Item Dequeue()
    {
        if (IsEmpty)
            throw new InvalidOperationException("The queue is empty, cannot dequeue anymore!");

        int randomIndex = random.Next(size);

        Node prevNode = null;
        Node currNode = head;

        while (randomIndex > 0)
        {
            prevNode = currNode;
            currNode = currNode.next;
            randomIndex--;
        }

        if (prevNode == null)
        {
            head = currNode.next;
        }
        else
        {
            prevNode.next = currNode.next;

            if (currNode.next == null)
                tail = prevNode;
        }

        size--;
        return currNode.value;
    }

    public Item Sample()
    {
        if (IsEmpty)
            throw new InvalidOperationException("The queue is empty, cannot dequeue anymore!");

        int randomIndex = random.Next(size);

        Node currNode = head;

        while (randomIndex > 0)
        {
            currNode = currNode.next;
            randomIndex--;
        }

        return currNode.value;
    }

    public IEnumerator<Item> GetEnumerator()
    {
        Item[] iteratorArray = new Item[size];
        Node currNode = head;
        int index = 0;

        while (currNode != null)
        {
            iteratorArray[index] = currNode.value;
            currNode = currNode.next;
            index++;
        }

        Iterator(iteratorArray);

        for (int i = 0; i < size; i++)
        {
            yield return iteratorArray[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void Iterator(Item[] array)
    {
        for (int i = 0; i < size; i++)
        {
            int randomIndex = random.Next(i, size);
            Item temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        RandomizedQueue<int> newQueue = new RandomizedQueue<int>();
        for (int i = 0; i < 20; i++)
            newQueue.Enqueue(i);
        IEnumerator<int> newIterator = newQueue.GetEnumerator();

        while (newIterator.MoveNext())
            Console.WriteLine(newIterator.Current);
    }
}
