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
        // add the item to the front
    }

    public void AddLast(Item item)
    {
        // add the item to the end
    }

    public Item RemoveFirst()
    {
        // remove and return the item from the front
        Item item = array[head];
        return item;
    }

    public Item RemoveLast()
    {
        // remove and return the item from the front
        Item item = array[tail];
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
        // unit testing (required)
        /*
         input: 11 23 42 1 3
         RemoveFirst; RemoveLast
         output: 23 42 1
         */
    }
}