using System;

// Define PropertyDemo class
public class PropertyDemo
{
    // Define properties
    // Complete Step 1:............
    public int value = 5;
}

// Define StaticDemo class
public class StaticDemo
{
    // Define static members
    // Complete Step 2:............
    public static int count;
    static StaticDemo()
    {
        Console.WriteLine("Static Constructor");
        count = 10;
    }
    public static void show()
    {
        Console.WriteLine("Static Method");
    }

}

// Define MathHelper static class
public static class MathHelper
{
    // Define static methods
    // Complete Step 3:............
    public static int add(int a, int b)
    {
        return a + b;
    }
    public static int sub(int a, int b)
    {
        return b - a;
    }
}

public class Program
{
    public static void Main()
    {
        // Demonstrate usage
        // Complete Step 4:............
        PropertyDemo pd = new PropertyDemo();
        Console.WriteLine(pd.value);
        Console.WriteLine("Private Value");
        Console.WriteLine(StaticDemo.count);
        StaticDemo.show();
        int res = MathHelper.add(pd.value, StaticDemo.count);
        Console.WriteLine(res);
        int resSub = MathHelper.sub(pd.value, StaticDemo.count);
        Console.WriteLine(resSub);
    }
}