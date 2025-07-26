using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        foreach (var name in Kata.FriendOrFoe(new[] { "Mark", "Jimmy", "Abel", "Amanda" }))
        {
            Console.WriteLine(name);
        }
    }
}
public class Kata
{
    public static IEnumerable<string> FriendOrFoe(string[] names) => 
        names.Where(name => name.Length == 4);
    
    public static int DescendingOrder2(int num) => Int32.Parse(
        string.Concat(num.ToString().OrderByDescending(x => x))
    );
    
    public static int DescendingOrder(int num) {
        var numArray = num.ToString().ToCharArray();
        Array.Sort(numArray);
        Array.Reverse(numArray);
        return Int32.Parse(numArray);
    }
    public static int SquareSum(int[] numbers) => numbers.Sum(i => i * i);

    public static string NumberToString(int num) => num.ToString();

    public static double basicOp(char operation, double value1, double value2)
    {
        return operation switch
        {
            '+' => value1 + value2,
            '-' => value1 - value2,
            '*' => value1 * value2,
            '/' => value1 / value2,
            _ => -1
        };
    }

    public static string MakeUpperCase(string str) => str.ToUpper();
    
    public static int StringToNumber(String str) => Int32.Parse(str);

    public static int Sum(int[] numbers) => numbers == null || numbers.Length < 3
    ? 0
    : numbers.Sum() - numbers.Max() - numbers.Min();

    public static bool BetterThanAverage(int[] ClassPoints, int YourPoints) => (Enumerable.Sum(ClassPoints) + YourPoints) / (ClassPoints.Length + 1) < YourPoints ? true : false;
}