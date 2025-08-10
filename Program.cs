using System;
using System.Collections.Generic;
using System.Linq;
using static Kata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Remove_char("eloquent"));
        Console.WriteLine($"位运算2的3次方：{1 << 3}");
        Console.WriteLine(CSharpTutorial.Hanoi(3));
        Console.WriteLine(CSharpTutorial.MySum(10));
        Console.WriteLine(Past(0, 1, 1));
        Console.WriteLine(summation2(8));

        foreach (var name in FriendOrFoe(new[] { "Mark", "Jimmy", "Abel", "Amanda" }))
        {
            Console.WriteLine(name);
        }
        Console.WriteLine(NbYear(1500, 5, 100, 5000));
    }

    class CSharpTutorial
    {
        // 给定 n 个大小各不相同的圆盘和三根柱子（A、B、C），初始时所有圆盘按照从大到小顺序叠在柱子 A 上。请你用程序输出将所有圆盘从柱子 A 移动到柱子 C 的步骤，移动规则如下：
        // 每次只能移动一个圆盘。
        // 任何时刻都不能把大盘子放在小盘子上面。
        // 圆盘只能放在三根柱子之一上。
        //
        // 输入： 一个整数 n (1 <= n <= 20)，表示圆盘数量。
        // 输出： 每一步移动的描述，例如：Move disk 1 from A to C
        public static int Hanoi2(int disks) => 1 << disks - 1;
        public static int Hanoi(int disks) => (int)(Math.Pow(2, disks) - 1);
        // 先把 n-1 移动到temp，再把单个移动到to，最后把n-1移动到to
        public static int MoveHanoi(int n, char from, char temp, char to)
        {
            if (n == 1)
            {
                Console.WriteLine($"Move disk 1 from {from} to {to}");
                return 1;
            }
            int times = MoveHanoi(n - 1, from, to, temp);
            Console.WriteLine($"Move disk {n} from {from} to {to}");
            times++;
            times += MoveHanoi(n - 1, temp, from, to);
            return times;
        }

        public static int MySum(int num)
        {
            if (num == 1)
                return 1;
            else
            {
                int sum = num + MySum(num - 1);
                return sum;
            }
        }
    }

}
public class Kata
{
    // In a small town the population is p0 = 1000 at the beginning of a year. The population regularly increases by 2 percent per year and moreover 50 new inhabitants per year come to live in the town. How many years does the town need to see its population greater than or equal to p = 1200 inhabitants?
    //     More generally given parameters:

    // p0, percent, aug (inhabitants coming or leaving each year), p (population to equal or surpass)

    // the function nb_year should return n number of entire years needed to get a population greater or equal to p.

    // aug is an integer, percent a positive or null floating number, p0 and p are positive integers (> 0)

    public static int NbYear(int p0, double percent, int aug, int p)
    {
        int years = 0;
        while (p0 < p)
        {
            years++;
            p0 = p0 + (int)(p0 * percent / 100) + aug;
        }
        return years;
    }

    public static double FindAverage(double[] array)
    {
        return array.Length == 0 ? 0 : array.Average();
    }
    // 范围表达式，s[1..^1]表示从字符串 s 的 第 1 个字符（索引为 1）开始，一直取到 倒数第 1 个字符之前（不包含倒数第 1 个字符）。
    // public static string Remove_char(string s) => s[1..^1];
    public static string Remove_char(string s) => s.Length >= 2 ? s.Substring(1, s.Length - 2) : "";
    public static int Past2(int h, int m, int s) => (int)new TimeSpan(h, m, s).TotalMilliseconds;
    public static int Past(int h, int m, int s) => s * 1000 + h * 3600000 + m * 60000;

    public static int summation2(int num) => Enumerable.Range(1, num).Sum();

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

    public static int DescendingOrder(int num)
    {
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