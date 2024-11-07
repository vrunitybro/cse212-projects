using System.Diagnostics;

public static class Algorithms {
    public static void Run() {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}", "n", "alg1-count", "alg2-count", "alg3-count",
            "alg1-time", "alg2-time", "alg3-time");
        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}", "----------");

        for (int n = 0; n < 15001; n += 1000) {
            int count1 = Algorithm1(n);
            int count2 = Algorithm2(n);
            int count3 = Algorithm3(n);
            double time1 = Time(Algorithm1, n, 10);
            double time2 = Time(Algorithm2, n, 10);
            double time3 = Time(Algorithm3, n, 10);
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15:0.00000}{5,15:0.00000}{6,15:0.00000}", n, count1, count2,
                count3, time1, time2,
                time3);
        }
    }

    private static double Time(Func<int, int> algorithm, int input, int times) {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i) {
            algorithm(input);
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm1(int size) {
        var count = 0;
        for (var i = 0; i < size; ++i)
            count += 1;

        return count;
    } //Prediction: Since it loops once through the data, it has a time complexity of O(n).

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm2(int size) {
        var count = 0;
        for (var i = 0; i < size; ++i)
        for (var j = 0; j < size; ++j)
            count += 1;

        return count;
        //Prediction: The work grows quadratically with the input size, so the time complexity is O(n²)
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm3(int size) {
        var count = 0;
        var start = 0;
        var end = size - 1;
        while (start <= end) {
            var middle = (end - start) / 2 + start;
            start = middle + 1;
            count += 1;
        }

        return count;
        //Prediction: The work grows logarithmically, so the time complexity is O(log n)
    }
}

Algorithm1 (O(n)):

// alg1-count increases linearly with n. For example, when n = 1000, alg1-count = 1000, and when n = 2000, alg1-count = 2000.
// Time Complexity: The time (alg1-time) increases slowly as n grows, which is consistent with the O(n) prediction.
// Algorithm2 (O(n²)):

// alg2-count increases quadratically with n. For example, when n = 1000, alg2-count = 1,000,000 (which is 1000²), and when n = 2000, alg2-count = 4,000,000 (which is 2000²).
// Time Complexity: The time (alg2-time) increases rapidly as n grows, confirming the O(n²) prediction. As n gets larger, the time difference becomes more pronounced.
// Algorithm3 (O(log n)):

// alg3-count increases logarithmically with n. The count values are much smaller compared to n, and the increase slows as n gets larger. For example, when n = 1000, alg3-count = 10, and even when n increases to 15000, alg3-count only increases to 14.
// Time Complexity: The time (alg3-time) remains almost constant and extremely low, which is typical for an O(log n) complexity.

// Best Performance: Algorithm3 has the best performance. The alg3-time values remain nearly constant and extremely small even as n grows, confirming that logarithmic time complexity is very efficient.
// Worst Performance: Algorithm2 has the worst performance. The alg2-time values increase dramatically as n grows, which is expected for quadratic time complexity.
