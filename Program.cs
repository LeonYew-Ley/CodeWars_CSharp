using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text.RegularExpressions;
using static Kata;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, CodeWars!");

        // SquareDigits 测试用例
        Console.WriteLine("\n=== SquareDigits 测试用例 ===");
        TestSquareDigits(9119, 811181);
        TestSquareDigits(765, 493625);
        TestSquareDigits(123, 149);
        TestSquareDigits(0, 0);
        TestSquareDigits(1, 1);
        TestSquareDigits(12, 14);
        TestSquareDigits(3212, 9414);
        TestSquareDigits(2112, 4114);

        // comp 方法测试用例
        Console.WriteLine("\n=== comp 方法测试用例 ===");
        TestComp();
    }

    private static void TestSquareDigits(int input, int expected)
    {
        int result = SquareDigits(input);
        string status = result == expected ? "✓ 通过" : "✗ 失败";
        Console.WriteLine($"SquareDigits({input}) = {result}, 期望: {expected} {status}");
    }

    private static void TestComp()
    {
        // 测试用例1：你提供的数组
        int[] a1 = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
        int[] b1 = new int[] { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
        bool result1 = comp(a1, b1);
        string status1 = result1 ? "✓ 通过" : "✗ 失败";
        Console.WriteLine($"comp(a1, b1) = {result1}, 期望: true {status1}");

        // 打印数组内容以便调试
        Console.WriteLine($"a1: [{string.Join(", ", a1)}]");
        Console.WriteLine($"b1: [{string.Join(", ", b1)}]");

        // 测试用例2：空数组
        int[] a2 = new int[] { };
        int[] b2 = new int[] { };
        bool result2 = comp(a2, b2);
        string status2 = result2 ? "✓ 通过" : "✗ 失败";
        Console.WriteLine($"comp(a2, b2) = {result2}, 期望: true {status2}");

        // 测试用例3：不匹配的数组
        int[] a3 = new int[] { 1, 2, 3 };
        int[] b3 = new int[] { 1, 4, 9, 16 }; // 长度不同
        bool result3 = comp(a3, b3);
        string status3 = result3 ? "✗ 失败" : "✓ 通过";
        Console.WriteLine($"comp(a3, b3) = {result3}, 期望: false {status3}");

        // 测试用例4：内容不匹配
        int[] a4 = new int[] { 1, 2, 3 };
        int[] b4 = new int[] { 1, 4, 8 }; // 8不是3的平方
        bool result4 = comp(a4, b4);
        string status4 = result4 ? "✗ 失败" : "✓ 通过";
        Console.WriteLine($"comp(a4, b4) = {result4}, 期望: false {status4}");
    }

    class CSharpTutorial
    {
        // 汉诺塔问题
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
    // 根据 bool 返回 string 类型的 Value
    public static string BooleanToString(bool b) => b ? "True" : "False";

    // 判断 a,b 两个数组（集合）是否相等（标准是：b的元素是a中的元素的平方）
    // 重数一致，不论顺序
    public static bool comp(int[] a, int[] b)
    {
        // 注意这里的判空操作，应该先判空，再访问Length，否则会报错 NullReferenceException
        if (a == null || b == null || a.Length != b.Length)
            return false;
        var aSquared = a.Select(x => x * x).OrderBy(x => x).ToArray();
        var bSorted = b.OrderBy(x => x).ToArray();
        bool ret = aSquared.SequenceEqual(bSorted);
        return ret;
    }

    // 返回一个数的每位平方后的数
    public static int SquareDigits(int n)
    {
        /* 取余写法、string.Join */
        // if (n == 0) return 0;

        // List<int> ints = [];
        // while (n > 0)
        // {
        //     int t = n % 10;
        //     ints.Add(t * t);
        //     n /= 10;
        // }
        // ints.Reverse();
        // string ret = string.Join("", ints);
        // return int.Parse(ret);

        /* String 和 string 的区别：
        string 才是关键字，用来调用一些 string 类的方法
        String 是类型名称，在using System 的时候使用
        
        string 会被编译成 System.String，两者使用上没什么区别 */

        /* Linq 写法 */

        return int.Parse(
            String.Concat(
                n.ToString()
                .Select(
                    x => (int)Math.Pow(char.GetNumericValue(x), 2)
                )
            )
        );
    }
    // 过滤出非负整数
    public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
    {
        // return listOfItems
        // .Where(x => x.GetType() == typeof(int))
        // .Select(x => (int)x);

        // return listOfItems
        // .Where(x => x is int)
        // .Cast<int>();

        return listOfItems.OfType<int>();
    }
    // 找出第一个不连续的数
    public static object FirstNonConsecutive_1(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] + 1 != arr[i])
                return arr[i];
        }
        return null;
    }

    public static object FirstNonConsecutive(int[] arr)
    {
        if (arr.Length <= 1)
            return null;
        int pre = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] - pre != 1)
                return arr[i];
            pre = arr[i];
        }
        return null;
    }


    // 返回复印作业需要的纸张数量
    public static int Paperwork(int n, int m) => n < 0 || m < 0 ? 0 : n * m;

    // 等差数列做分母求和_CodeWars Solution
    public static string seriesSum_CodeWars(int n)
    {
        return (from i in Enumerable.Range(0, n) select 1.0 / (3.0 * i + 1)).Sum().ToString("0.00");
    }
    // 等差数列做分母求和
    const double EulerGamma = 0.57721566490153286060;        // 欧拉-马歇罗尼常数

    static double Digamma(double x)
    {
        // 如果 x 小，用递推避免出错
        if (x < 6)
        {
            return Digamma(x + 1) - 1.0 / x;
        }
        // 近似展开
        double inv = 1.0 / x;
        double inv2 = inv * inv;
        return Math.Log(x) - 0.5 * inv - inv2 / 12.0;
    }
    public static string seriesSum(int n)
    {
        if (n == 0)
        {
            return "0.00";
        }
        double left = Digamma((double)1 / 3 + n);
        double right = Digamma((double)1 / 3);
        return ((left - right) / 3).ToString("F2");
    }


    // 根据首字母返回是否弹吉他
    public static string AreYouPlayingBanjo(string name) =>
    name.First<char>().Equals('R') || name.First<char>().Equals('r')
    ? $"{name} plays banjo"
    : $"{name} does not play banjo";

    // 数组中每个数字出现的次数不超过x次，超过的删除
    public static int[] DeleteNth(int[] arr, int x)
    {
        var count = new Dictionary<int, int>();
        var result = arr.Select(num =>
        {
            count.TryGetValue(num, out int times);
            if (times < x)
            {
                count[num] = times + 1;
                return (include: true, value: num);
            }
            count[num] = times + 1;
            return (include: false, value: num);
        })
        .Where(pair => pair.include)
        .Select(pair => pair.value)
        .ToArray();
        return result;
    }

    public static int[] DeleteNth_Dict(int[] arr, int x)
    {
        List<int> result = [];
        Dictionary<int, int> count = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            int num = arr[i];
            count.TryGetValue(num, out int times);
            if (times < x)
                result.Add(num);
            count[num] = times + 1;
        }
        return result.ToArray();
    }

    public static int[] DeleteNth_Origin(int[] arr, int x)
    {
        List<int> result = [];
        int[] count = new int[arr.Max() + 1];
        int actualLength = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (count[arr[i]] < x)
            {
                result.Add(arr[i]);
                actualLength++;
            }
            count[arr[i]]++;
        }
        return result.ToArray();
    }
    // 返回字符串中的 'X' 和 'O' 数量是否相等
    public static bool XO(string input)
    => input.ToLower().Count(c => c == 'x') == input.ToLower().Count(c => c == 'o');
    // 找出数组中出现奇数次的元素
    public static int Find_it_single_line(int[] seq)
    => seq.GroupBy(x => x)
        .First(g => g.Count() % 2 == 1)
        .Key;

    public static int Find_it(int[] seq)
    {
        var groups = seq.GroupBy(x => x);
        foreach (var group in groups)
        {
            if (group.Count() % 2 == 1)
            {
                return group.Key;
            }
        }
        return 0;
    }
    // 点赞文案（String.Format版本）
    public static string Likes_FormatVersion(string[] name)
    {
        string[] pattern = {
            "no one likes this",
            "{0} likes this",
            "{0} and {1} like this",
            "{0}, {1} and {2} like this",
            "{0}, {1} and {2} others like this"
        };

        return
        name.Length < 4 ?
        String.Format(pattern[name.Length], name)
        : String.Format(pattern[4], name[0], name[1], name.Length - 2);
    }

    // 点赞文案（Switch语法糖版本）
    public static string Likes(string[] name)
    {
        return name.Length switch
        {
            0 => "no one likes this",
            1 => $"{name[0]} likes this",
            2 => $"{name[0]} and {name[1]} like this",
            3 => $"{name[0]}, {name[1]} and {name[2]} like this",
            _ => $"{name[0]}, {name[1]} and {name.Length - 2} others like this",
        };
    }

    // 修正错别字（字典版本）
    public static string Correct_MoreReusable(string text)
    {
        Dictionary<char, char> correctMap = new Dictionary<char, char>{
            {'5', 'S'},
            {'0', 'O'},
            {'1', 'I'}
        };
        foreach (var item in correctMap)
        {
            text = text.Replace(item.Key, item.Value);
        }
        return text;
    }

    // 修正错别字（暴力替换）
    public static string Correct(string text) => text.Replace('5', 'S').Replace('0', 'O').Replace('1', 'I');

    // 插入空格（正则表达式）
    public static string BreakCamelCase(string str)
    => Regex.Replace(str, "(?<!^)([A-Z])", " $1");
    /*
    If you look down the middle of the triangle, you will see square numbers (you don't see them on even rows) like
    1, 4, 9, 16, 25, 36...
    
             1                 <-- middle number is 1
          3     5              <-- middle number is 4
       7     9    11           <-- middle number is 9
   13    15     17    19       <-- middle number is 16
21    23    25     27    29    <-- middle number is 25

    The middle number is also the average of the row numbers
    * The average of the second row is 4: (3+5)/2
    * The average of the third  row is 9: (7+9+11)/3

    To work out the sum of a sequence we can multiply the average by the number of terms in the sequence

    Notice that the second row has 2 terms, the third row has 3 terms, the Nth row has N terms
    
    So to find a sum of a row we can multiply the average (the square of the row number) by the number of terms 
    (also the row number)

    This means that the answer is actually simply the cube (power 3) of the row number
    
    */
    public static long RowSumOddNumbers(long n) => n * n * n;
    public static IEnumerable<string> OpenOrSenior_AI_Lambda(int[][] data)
    => data.Select(single => (single[0] >= 55 && single[1] > 7) ? "Senior" : "Open");
    public static IEnumerable<string> OpenOrSenior(int[][] data)
    {
        var stats = new List<string>();
        foreach (var single in data)
        {
            stats.Add((single[0] >= 55 && single[1] > 7) ? "Senior" : "Open");
        }
        return stats;
    }
    // 请你思考，使用最简洁的代码
    public static int GetVowelCount_AI(string str)
        => str.Count(c => "aeiou".Contains(c));
    public static int GetVowelCount(string str)
    {
        int vowelCount = 0;
        string vowelString = "aeiou";
        foreach (char c in str)
        {
            if (vowelString.Contains(c))
            {
                vowelCount++;
            }
        }
        return vowelCount;
    }
    public static int RentalCarCost_MoreSimple(int d) => d * 40 - (d >= 7 ? 50 : d >= 3 ? 20 : 0);
    public static int RentalCarCost_Lambda(int d) => d < 3 ? d * 40 : ((d >= 3 && d < 7) ? d * 40 - 20 : d * 40 - 50);
    public static int RentalCarCost(int d)
    {
        if (d < 3)
        {
            return d * 40;
        }
        if (d >= 3 && d < 7)
        {
            return d * 40 - 20;
        }
        return d * 40 - 50;
    }
    public static bool IsTriangle(int a, int b, int c) => (a + b > c) && (a + c > b) && (b + c > a);
    public static bool ValidatePin(string pin)
    {
        return Regex.IsMatch(pin, @"^(\d{6}|\d{4})\z");
    }
    public static string HoopCount(int n) => n >= 10 ? "Great, now move on to tricks" : "Keep at it until you get it";
    public static bool IsSquare(int n) => Math.Sqrt(n) % 1 == 0;
    public static bool ZeroFuel(uint distanceToPump, uint mpg, uint fuelLeft) => distanceToPump <= mpg * fuelLeft;
    public static string[] StringToArray(string str) => str.Split(' ');
    public static char GetGrade(int s1, int s2, int s3)
    {
        int average = (s1 + s2 + s3) / 3;
        return average switch
        {
            >= 90 => 'A',
            >= 80 => 'B',
            >= 70 => 'C',
            >= 60 => 'D',
            _ => 'F'
        };
    }
    public static int CountSheeps(bool[] sheeps) => sheeps.Count(x => x);
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