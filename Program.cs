using System;
using System.Text;
using System.Threading;

class Program
{
    static bool ArrayContains(int[] numbers, int number)
    {
        foreach (var num in numbers) if (number == num) return true;
        return false;
    }
    static int[] UniqueRandomArray(int min, int max, int length, Random? random = null)
    {
        if (min >= max) throw new ArgumentException("Не верно задан диапазон - min >= max");
        if ((max - min) <= length) throw new ArgumentException("Диапазон не позволяет");

        random = random ?? new Random(DateTime.Now.Millisecond);
        var result = new int[length];
        var zeroFirst = true;
        for (var i = 0; i < length; i++)
        {
            var res = 0;
            do
            {
                res = random.Next(min, max);
                if (res == 0)
                {
                    if (zeroFirst)
                    {
                        zeroFirst = false;
                        break;
                    }
                    continue;
                }
            } while (ArrayContains(result, res));
            result[i] = res;
        }
        return result;
    }
    static string ArrayToString(int[] numbers, bool show = true)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var item in numbers) sb.Append(item).Append(' ');
        var result = sb.ToString().TrimEnd(' ');
        if (show) Console.WriteLine(result);
        return result;
    }

    static void Main()
    {
        var A = UniqueRandomArray(-100, 100, 15);
        ArrayToString(A);
        int Min = 0, Max = 0;
        int IndMax = A[0], IndMin = A[0];
        for (int i = 0; i <= A.Length; i ++)
        {
            if (A[i] > Max)
            {
                Max = A[i];
                IndMax = i;
            }
            else if(A[i] < Min)
            {
                Min = A[i];
                IndMin = i;
            }
        }
        int temp = A[IndMin];
        A[IndMin] = A[IndMax];
        A[IndMax] = temp;
        ArrayToString(A);
    }
}

