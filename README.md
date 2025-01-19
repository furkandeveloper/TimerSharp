<p align="center">
  <img src="https://github.com/user-attachments/assets/c5a088e2-6489-47af-b146-89d0ba633e78" style="max-width:100%;" height="100" />
</p>

# TimerSharp Documentation

**TimerSharp** is a lightweight library designed to measure and log the execution time of methods in C#. It can be used in both Console and API applications. With `MethodTimer`, you can easily measure how long your methods take to execute and log the results in a customized format.

---

## Installation

To install `TimerSharp`, add the NuGet package `TimerSharp.Core` to your project:

```bash
dotnet add package TimerSharp.Core
```
Alternatively, you can search for TimerSharp.Core in the NuGet Package Manager in Visual Studio.


### Features
- Method Execution Timer: Automatically logs the execution time of any method.
- Nanosecond Precision: Provides logging with millisecond and nanosecond precision.


## How to Use TimerSharp

First, add the `MethodTimer` attribute to any method you want to measure. The timer will automatically start and stop when the method is called.

```csharp
using TimerSharp.Core;

public class Example
{
    [MethodTimer]
    public void MyMethod()
    {
        // Simulate some work
        System.Threading.Thread.Sleep(1000);
    }
}
```

In this example, the method `MyMethod` will be timed. Upon execution, it will log how long it took to run, in milliseconds and nanoseconds.


## Examples

### Console App
``` csharp
using TimerSharp.Core;

public class Program
{
    public static void Main(string[] args)
    {
        var example = new Example();
        example.MyMethod();
    }
}

public class Example
{
    [MethodTimer]
    public void MyMethod()
    {
        // Simulate work with a delay
        System.Threading.Thread.Sleep(1000);
    }
}
```

When you run the program, it will output:

```bash
Method MyMethod took 1000.000000 ms to execute.
```



