using System;
using System.Collections;
using System.Collections.Generic;

public class RandomizedQueue<Item> : IEnumerable<Item>
{
    private Item[] hiddenArray;
    private int size;
    private int pointer;
    private static int initialArraySize = 4;
    private Random random;

    public RandomizedQueue()
    {
        hiddenArray = new Item[initialArraySize];
        size = 0;
        pointer = 0;
        random = new Random();
    }

    public bool IsEmpty => size == 0;
    public int Size => size;

    public void Enqueue(Item item)
    {
        if (pointer >= hiddenArray.Length)
            Resize(hiddenArray.Length * 2);
        hiddenArray[pointer] = item;
        pointer++;
        size++;
    }

    private void Resize(int newSize)
    {
        Item[] newArray = new Item[newSize];
        Array.Copy(hiddenArray, newArray, size);
        hiddenArray = newArray;
    }

    public Item Dequeue()
    {
        if (size <= 0)
            throw new InvalidOperationException("The queue is empty, cannot dequeue anymore!");

        int index = random.Next(size);
        Item tempValue = hiddenArray[index];
        hiddenArray[index] = hiddenArray[pointer - 1];
        hiddenArray[pointer - 1] = default;
        pointer--;
        size--;

        if (size <= hiddenArray.Length / 4.0 && size >= initialArraySize)
        {
            Resize(size);
        }

        return tempValue;
    }

    public Item Sample()
    {
        if (size <= 0)
            throw new InvalidOperationException("The queue is empty, cannot dequeue anymore!");

        int index = random.Next(size);
        Item tempValue = hiddenArray[index];
        return tempValue;
    }

    public IEnumerator<Item> GetEnumerator()
    {
        Item[] iteratorArray = new Item[size];
        Array.Copy(hiddenArray, iteratorArray, size);
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

