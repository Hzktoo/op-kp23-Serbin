using System;

class Percolation
{
    // test cases
    static bool testisOpen()
    {
        int[,] testgrid1 = { { 0, 2, 0, 2 }, { 1, 2, 1, 2 }, { 1, 1, 2, 1 }, { 2, 2, 1, 2 } };
        int[,] testgrid2 = { { 0, 2, 2, 2 }, { 1, 1, 2, 1 }, { 1, 1, 1, 2 }, { 1, 1, 2, 2 } };
        int[,] testgrid3 = { { 0, 0, 2, 0 }, { 1, 2, 2, 1 }, { 1, 2, 2, 1 }, { 1, 2, 1, 1 } };
        bool testisOpen = true;
        if (testisOpen != isOpen(1, 1, testgrid1) || testisOpen != isOpen(1,1, testgrid2) || testisOpen != isOpen(1, 1, testgrid3))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    static bool testisFull()
    {
        int[,] testgrid1 = { { 0, 2, 0, 2 }, { 1, 2, 1, 2 }, { 1, 1, 2, 1 }, { 2, 2, 1, 2 } };
        int[,] testgrid2 = { { 0, 2, 2, 2 }, { 1, 1, 2, 1 }, { 1, 1, 1, 2 }, { 1, 1, 2, 2 } };
        int[,] testgrid3 = { { 0, 0, 2, 0 }, { 1, 2, 2, 1 }, { 1, 2, 2, 1 }, { 1, 2, 1, 1 } };
        bool testisFull = true;
        if (testisFull != isFull(1, 1, testgrid1) || testisFull != isFull(1, 1, testgrid2) || testisFull != isFull(1, 1, testgrid3))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    static bool testpercolates()
    {
        int[,] testgrid1 = { { 0, 2, 0, 2 }, { 1, 2, 1, 2 }, { 1, 1, 2, 1 }, { 2, 2, 1, 2 } };
        int[,] testgrid2 = { { 0, 2, 2, 2 }, { 1, 1, 2, 1 }, { 1, 1, 1, 2 }, { 1, 1, 2, 2 } };
        int[,] testgrid3 = { { 0, 0, 2, 0 }, { 1, 2, 2, 1 }, { 1, 2, 2, 1 }, { 1, 2, 1, 1 } };
        bool testpercolates = true;
        if (testpercolates != percolates(testgrid1) || testpercolates != percolates(testgrid2) || testpercolates != percolates(testgrid3))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    // creates n-by-n grid, with all sites initially blocked
    static int [, ] init(int n)
    {
        Random rnd = new Random();
        int[,] Matrix = new int[n, n];
        int x;
        return Matrix;
    }
    // opens the site (row, col) if it is not open already
    static int[,] open(int row, int col, int[,] grid)
    {
        int value1 = 2;
        int value2 = 2;
        int value3 = 2;
        int value4 = 2;
        return grid;
    }

    // is the site (row, col) open?
    static bool isOpen(int row, int col, int[,] grid)
    {
        grid = new int[row, col];
        return true;
        return false;
    }

    // is the site (row, col) full?
    static bool isFull(int row, int col, int[,] grid)
    {
        grid = new int[row, col];
        return true;
        return false;
    }

    // returns the number of open sites
    static int numberOfOpenSites(int[,] grid)
    {
        int amount = 0;
        return amount;
    }


    // does the system percolate?
    static bool percolates(int[,] grid)
    {
        int i = 0;
        int j = 0;
        grid = new int[i, j];
        return true;
        return false;
    }

    // prints the matrix on the screen
    // The method should display different types of sites (open, blocked, full)
    static void print()
    {
        int[,] grid = new  int[0, 0];
        Console.WriteLine(grid);
    }
    // test client (optional)
    static void main(String[] args)
    {
        int[,] grid = init(6);
        print(grid); 
    }
}
