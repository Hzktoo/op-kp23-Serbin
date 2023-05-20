interface IVessel
{
    void PrepareToMovement();
    void Move();
}

class SailingVessel : IVessel
{
    public void PrepareToMovement()
    {
        Console.WriteLine("Preparing the sailing vessel to move.");
    }

    public void Move()
    {
        Console.WriteLine("Moving the sailing vessel.");
    }
}

class Submarine : IVessel
{
    public void PrepareToMovement()
    {
        Console.WriteLine("Preparing the submarine to move.");
    }

    public void Move()
    {
        Console.WriteLine("Moving the submarine.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IVessel vessel1 = new SailingVessel();
        IVessel vessel2 = new Submarine();

        vessel1.PrepareToMovement();
        vessel1.Move();

        vessel2.PrepareToMovement();
        vessel2.Move();
    }
}