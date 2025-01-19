// See https://aka.ms/new-console-template for more information
using TimerSharp.Core;

Console.WriteLine("Hello, World!");
var op = new Operation();
op.DoWork();    

public class Operation
{
    [MethodTimer]
    public void DoWork()
    {
        Console.WriteLine("Doing work...");
    }
}