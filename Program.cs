using System;
using System.Collections.Generic;
using System.Linq;
using static Kata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Past(0,1,1));
        Console.WriteLine(summation2(8));
        
        foreach (var name in FriendOrFoe(new[] { "Mark", "Jimmy", "Abel", "Amanda" }))
        {
            Console.WriteLine(name);
        }
    }

}
public class Kata
{
    public static int Past2(int h, int m, int s) => (int)new TimeSpan(h,m,s).TotalMilliseconds;
    public static int Past(int h, int m, int s) => s*1000 + h*3600000 + m*60000;
    
    public static int summation2(int num) => Enumerable.Range(1,num).Sum();
    
    public static int summation(int num)
    {
        int sum = 0;
        for (int i = 1; i <= num; i++)
        {
            sum += i;
        }

        return sum;
    }
    
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