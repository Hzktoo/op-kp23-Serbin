using System;
abstract class Vessel
{
    public abstract void PrepareToMovement();
    public abstract void Move();
}

class SailingVessel : Vessel
{
    public override void PrepareToMovement()
    {
        Console.WriteLine("Preparing the sailing vessel to move.");
    }

    public override void Move()
    {
        Console.WriteLine("Moving the sailing vessel.");
    }
}

class Submarine : Vessel
{
    public override void PrepareToMovement()
    {
        Console.WriteLine("Preparing the submarine to move.");
    }

    public override void Move()
    {
        Console.WriteLine("Moving the submarine.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vessel vessel1 = new SailingVessel();
        Vessel vessel2 = new Submarine();

        vessel1.PrepareToMovement();
        vessel1.Move();

        vessel2.PrepareToMovement();
        vessel2.Move();
    }
}