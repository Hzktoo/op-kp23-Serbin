using System;
using System.Collections;
using System.Collections.Generic;

public class Deque<Item> : IEnumerable<Item>
{
    private Item[] array;
    private int head;
    private int tail;
    private int size;

    public Deque()
    {
        const int defaultCapacity = 4;
        array = new Item[defaultCapacity];
        head = 0;
        tail = 0;
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

        if (size == array.Length)
        {
            ResizeArray();
        }

        head = (head - 1 + array.Length) % array.Length;
        array[head] = item;
        size++;
    }

    public void AddLast(Item item)
    {
        if (item == null)
        {
            throw new ArgumentException("Cannot add a null item into this deque!");
        }

        if (size == array.Length)
        {
            ResizeArray();
        }

        array[tail] = item;
        tail = (tail + 1) % array.Length;
        size++;
    }

    public Item RemoveFirst()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("The deque is empty, nothing to remove.");
        }

        Item item = array[head];
        array[head] = default(Item);
        head = (head + 1) % array.Length;
        size--;

        if (size > 0 && size == array.Length / 4)
        {
            ResizeArray();
        }

        return item;
    }

    public Item RemoveLast()
    {
        if (size == 0)
        {
            throw new InvalidOperationException("The deque is empty, nothing to remove.");
        }

        tail = (tail - 1 + array.Length) % array.Length;
        Item item = array[tail];
        array[tail] = default(Item);
        size--;

        if (size > 0 && size == array.Length / 4)
        {
            ResizeArray();
        }

        return item;
    }

    private void ResizeArray()
    {
        int newCapacity = size * 2;
        Item[] newArray = new Item[newCapacity];

        for (int i = 0; i < size; i++)
        {
            newArray[i] = array[(head + i) % array.Length];
        }

        array = newArray;
        head = 0;
        tail = size;
    }

    public IEnumerator<Item> GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            yield return array[(head + i) % array.Length];
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
        deque.AddFirst(1);
        deque.AddLast(0);
        deque.AddLast(8);
        deque.AddLast(9);
        deque.RemoveFirst();
        deque.AddLast(54);
        deque.RemoveLast();
        deque.AddFirst(10);
        deque.AddLast(2);
        deque.AddLast(4);

        foreach (int i in deque)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}