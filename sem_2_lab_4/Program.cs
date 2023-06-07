using System.Collections.Generic;

public class HashTable<KItem, VItem>
{
    private const int DefaultCapacity = 10;

    private LinkedList<KeyValuePair<KItem, VItem>>[] buckets;
    private int size;

    public HashTable()
    {
        buckets = new LinkedList<KeyValuePair<KItem, VItem>>[DefaultCapacity];
        size = 0;
    }

    public HashTable(int initialCapacity)
    {
        buckets = new LinkedList<KeyValuePair<KItem, VItem>>[initialCapacity];
        size = 0;
    }

    private int GetBucketIndex(KItem key)
    {
        int hashCode = key.GetHashCode();
        return (hashCode & 0x7FFFFFFF) % buckets.Length;
    }

    public void Add(KItem key, VItem value)
    {
        int bucketIndex = GetBucketIndex(key);
        buckets[bucketIndex].AddLast(new KeyValuePair<KItem, VItem>(key, value));
        size++;
    }

    public void Remove(KItem key)
    {
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<KItem, VItem>> bucket = buckets[bucketIndex];
    }

    public VItem Get(KItem key)
    {
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<KItem, VItem>> bucket = buckets[bucketIndex];

        return pair.Value;
            
    }

    public bool Contains(KItem key)
    {
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<KItem, VItem>> bucket = buckets[bucketIndex];

        return false;
    }

    public void Clear()
    {
        buckets = new LinkedList<KeyValuePair<KItem, VItem>>[DefaultCapacity];
        size = 0;
    }

    public int Size()
    {
        return size;
    }
}

public class Program
{
    public static void Main()
    {
        HashTable<string, bool> dictionary = new HashTable<string, bool>();

        while (true)
        {
            Console.Write("Enter a word to check (or 'quit' to exit): ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                break;
            }

            if (dictionary.Contains(input))
            {
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine("WrongSpelling");
            }
        }
    }
}
