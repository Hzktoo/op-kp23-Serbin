using System.Collections.Generic;

/*
Test scenariouses:
Test 1
Input: cherry;
Output: Ok;
Test 2
Input: case;
Output: WrongSpelling;
Test 3
Input: people;
Output: WrongSpelling;
Test 4
Input: cherry;
Output: Ok;
Test 5
Input: yes
Output: WrongSpelling;
Test 6
Input: mobile;
Output: WrongSpelling.
 */
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
        if (buckets[bucketIndex] == null)
        {
            buckets[bucketIndex] = new LinkedList<KeyValuePair<KItem, VItem>>();
        }

        foreach (KeyValuePair<KItem, VItem> pair in buckets[bucketIndex])
        {
            if (pair.Key.Equals(key))
            {
                throw new ArgumentException("An element with the same key already exists.");
            }
        }

        buckets[bucketIndex].AddLast(new KeyValuePair<KItem, VItem>(key, value));
        size++;
    }

    public void Remove(KItem key)
    {
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<KItem, VItem>> bucket = buckets[bucketIndex];

        if (bucket != null)
        {
            LinkedListNode<KeyValuePair<KItem, VItem>> current = bucket.First;
            while (current != null)
            {
                if (current.Value.Key.Equals(key))
                {
                    bucket.Remove(current);
                    size--;
                    return;
                }
                current = current.Next;
            }
        }

        throw new KeyNotFoundException("The specified key was not found.");
    }

    public VItem Get(KItem key)
    {
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<KItem, VItem>> bucket = buckets[bucketIndex];

        if (bucket != null)
        {
            foreach (KeyValuePair<KItem, VItem> pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
        }

        throw new KeyNotFoundException("The specified key was not found.");
    }

    public bool Contains(KItem key)
    {
        int bucketIndex = GetBucketIndex(key);
        LinkedList<KeyValuePair<KItem, VItem>> bucket = buckets[bucketIndex];

        if (bucket != null)
        {
            foreach (KeyValuePair<KItem, VItem> pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    return true;
                }
            }
        }

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
        dictionary.Add("apple", true);
        dictionary.Add("banana", true);
        dictionary.Add("cherry", true);
        dictionary.Add("date", true);
        dictionary.Add("elephant", true);
        dictionary.Add("flower", true);
        dictionary.Add("giraffe", true);
        dictionary.Add("honey", true);
        dictionary.Add("island", true);
        dictionary.Add("jaguar", true);
        dictionary.Add("kangaroo", true);
        dictionary.Add("leopard", true);
        dictionary.Add("mango", true);
        dictionary.Add("night", true);
        dictionary.Add("orange", true);
        dictionary.Add("peacock", true);
        dictionary.Add("quilt", true);
        dictionary.Add("rabbit", true);
        dictionary.Add("sunflower", true);
        dictionary.Add("tiger", true);
        dictionary.Add("umbrella", true);
        dictionary.Add("violin", true);
        dictionary.Add("waterfall", true);
        dictionary.Add("xylophone", true);
        dictionary.Add("yacht", true);
        dictionary.Add("zebra", true);
        dictionary.Add("almond", true);
        dictionary.Add("blueberry", true);
        dictionary.Add("cat", true);
        dictionary.Add("dog", true);
        dictionary.Add("elephant", true);
        dictionary.Add("frog", true);
        dictionary.Add("guitar", true);
        dictionary.Add("hippo", true);
        dictionary.Add("igloo", true);
        dictionary.Add("jazz", true);
        dictionary.Add("koala", true);
        dictionary.Add("lion", true);
        dictionary.Add("monkey", true);
        dictionary.Add("nut", true);
        dictionary.Add("ocean", true);
        dictionary.Add("penguin", true);
        dictionary.Add("queen", true);
        dictionary.Add("rose", true);
        dictionary.Add("sun", true);
        dictionary.Add("tulip", true);
        dictionary.Add("unicorn", true);
        dictionary.Add("volcano", true);
        dictionary.Add("whale", true);
        dictionary.Add("xylophone", true);
        dictionary.Add("yoga", true);
        dictionary.Add("zeppelin", true);

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
