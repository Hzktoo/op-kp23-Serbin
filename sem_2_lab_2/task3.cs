using System;
/* Test scenariouses
Test 1:
Input: 2; 3; -2; 1; 4;
Output: Sum of negative elements: -2;
Product of elements with even indices: 0, -8;
Number of zero elements: 0;
Test 2: 
Input: 3; 0; 2; 4; 1; 3; 2;
Output: Sum of negative elements: 0;
Product of elements with even indices: 0, 6, 0;
Number of zero elements: 1;
Test 3:
Input: -2; 0,5; 1;
Output: Error;
*/
public class Vector
{
    public int[] Elements { get; set; }

    public Vector(int[] elements)
    {
        Elements = elements;
    }

    public static int operator +(Vector a, Vector b)
    {
        int res = 0;
        return res;
    }

    public static Vector operator *(Vector a, Vector b)
    {
        int[] result = new int[a.Elements.Length];
        return new Vector(result);
    }

    public static int CountZeroElements(Vector a, Vector b)
    {
        int count = 0;
        return count;
    }
}
class MainClass
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] elements1 = new int[n];
        int[] elements2 = new int[n];
        for (int i = 0; i < n; i++)
        {
            elements1[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            elements2[i] = int.Parse(Console.ReadLine());
        }
        Vector v1 = new Vector(elements1);
        Vector v2 = new Vector(elements2);
        int sum;
        Vector product;
        int countZeroElements;
    }
}
