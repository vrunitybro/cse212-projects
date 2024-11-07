﻿/// <summary>
/// These 3 functions will (in different ways) calculate the standard
/// deviation from a list of numbers.  The standard deviation
/// is defined as the square root of the variance.  The variance is 
/// defined as the average of the squared differences from the mean.
/// </summary>
public static class StandardDeviation {
    public static void Run() {
        var numbers = new[] { 600, 470, 170, 430, 300 };
        Console.WriteLine(StandardDeviation1(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation2(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation3(numbers)); // Should be 147.322 
    }

    private static double StandardDeviation1(int[] numbers) {
        var total = 0.0;
        var count = 0;
        foreach (var number in numbers) {
            total += number;
            count += 1;
        }

        var avg = total / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers) {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }

    // The function iterates through numbers twice:
    // The first foreach loop calculates the total and count (O(n)).
    // The second foreach loop calculates the sum of squared differences (O(n)).
    // Big O Notation: O(n + n) = O(n)

    private static double StandardDeviation2(int[] numbers) {
        var sumSquaredDifferences = 0.0;
        var countNumbers = 0;
        foreach (var number in numbers) {
            var total = 0;
            var count = 0;
            foreach (var value in numbers) {
                total += value;
                count += 1;
            }

            var avg = total / count;
            sumSquaredDifferences += Math.Pow(number - avg, 2);
            countNumbers += 1;
        }

        var variance = sumSquaredDifferences / countNumbers;
        return Math.Sqrt(variance);

        // This function contains two nested foreach loops:
        // The outer foreach loop iterates through numbers (O(n)).
        // The inner foreach loop also iterates through numbers (O(n)).
        // Big O Notation: O(n × n) = O(n²)
    }

    private static double StandardDeviation3(int[] numbers) {
        var count = numbers.Length;
        var avg = (double)numbers.Sum() / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers) {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }

    // numbers.Sum() iterates through numbers once (O(n)).
    // The foreach loop iterates through numbers again (O(n)).
    // Big O Notation: O(n + n) = O(n)



//  SortArray Function: O(n²)
//  StandardDeviation1 Function: O(n)
//  StandardDeviation2 Function: O(n²)
//  StandardDeviation3 Function: O(n)

//  
// Merge Sort Algorithm: O(n log n) — This is an efficient, comparison-based sorting algorithm.
// Traveling Salesman Problem (TSP): O(2^n) — This represents exponential time complexity, where the time grows extremely fast as n increases.
}