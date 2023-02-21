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
    static int [,] init(int n)
    {
        Random rnd = new Random();
        int[,] Matrix = new int[n, n];
        int x;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                x = rnd.Next(2);
                if (x == 0)
                {
                    Matrix[i, j] = 2;
                }
                else if (x == 1 && i == 0)
                {
                    Matrix[i, j] = 0;
                }
                else if (x == 1)
                {
                    Matrix[i, j] = 1;
                }
            }
        }
        return Matrix;
    }
    
    // opens the site (row, col) if it is not open already
    static int [,] open(int row, int col, int[,] grid)
    {
        int value1 = 2;
        int value2 = 2;
        int value3 = 2;
        int value4 = 2;
        if (row != 0)
        {
            value1 = grid[row - 1, col];
        }
        if (col != 0)
        {
            value2 = grid[row, col - 1];
        }
        if (row < grid.GetLength(0) - 1)
        {
            value3 = grid[row + 1, col];
        }
        if (col < grid.GetLength(1) - 1)
        {
            value4 = grid[row, col + 1];
        }
        if (grid[row, col] == 1 && (value1 == 0 || value2 == 0 || value3 == 0 || value4 == 0))
        {
            grid[row, col] = 0;
            return grid;
        }
        return grid;
    }

    // is the site (row, col) open?
    static bool isOpen(int row, int col, int[,] grid)
    {
        grid = new int[row, col];
        if (grid[row, col] == 2)
        {
            return false;
        }
        return true;
    }

    // is the site (row, col) full?
    static bool isFull(int row, int col, int[,] grid)
    {
        grid = new int[row, col];
        if (grid[row, col] == 1)
        {
            return false;
        }
        return true;
    }

    // returns the number of open sites
    static int numberOfOpenSites(int[,] grid)
    {
        int amount = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 0 || grid[i, j] == 1)
                {
                    amount++;
                }
            }
        }
        return amount;
    }

    // does the system percolate?
    static bool percolates(int[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            if (grid[grid.GetLength(1) - 1, i] == 0)
            {
                return true;
            }
        }
        return false;
    }

    // prints the matrix on the screen
    // The method should display different types of sites (open, blocked, full)
    static void print(int[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.WriteLine();
        }
    }

    //the method, that changes "1" to "0" if it needed
    static int[,] ChangingNumber(int[,] grid)
    {
        int sum = 0;
        int etalonsum = 0;
        bool x = true;
        while (x)
        {
            etalonsum = sum;
            sum = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid = open(i, j, grid);
                    sum += grid[i, j];
                }
            }
            if (etalonsum == sum)
            {
                x = false;
            }
        }
        return grid;
    }

    // test client (optional)
    static void Main(String[] args)
    {
        int[,] grid = init(6);
        print(grid);
        Console.ReadLine();
        Console.WriteLine();
        grid = ChangingNumber(grid);
        print(grid);
        Console.ReadLine();
        Console.Clear();
        bool yes = true;
        if (yes = percolates(grid))
        {
            Console.WriteLine("System percolates");
        }
        else
        {
            Console.WriteLine("System does not percolate");
        }
    }
}
