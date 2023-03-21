using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class CSharpDemo : MonoBehaviour
{
    // Expression lambda
    // (input-parameters) => expression

    // Statement lambda
    // (input-parameters) => { <sequence-of-statements> }

    [ContextMenu("Lambda expressions Ex 1")]
    public void LamdaEx1()
    {
        Func<int, int> square = x => x * x;
        Debug.Log(square(5));

        System.Linq.Expressions.Expression<Func<int, int>> e = x => x * x;
        Debug.Log(e);

        int[] numbers = { 2, 3, 4, 5 };
        var squaredNumbers = numbers.Select(x => x * x);
        Debug.Log(string.Join(" ", squaredNumbers));
    }

    [ContextMenu("Lambda expressions Ex 2")]
    public void LamdaEx2()
    {
        Action<string> greet = name =>
        {
            string greeting = $"Hello {name}!";
            Debug.Log(greeting);
        };
        greet("World");
    }

    [ContextMenu("Lambda expressions Ex 3")]
    public void LamdaEx3()
    {
        Action line = () => Debug.Log("");

        Func<double, double> cube = x => x * x * x;

        Func<int, int, bool> testForEquality = (x, y) => x == y;

        Func<int, string, bool> isTooLong = (int x, string s) => s.Length > x;

        // C# 9, use discards
        Func<int, int, int> constant = (_, _) => 42;
    }

    [ContextMenu("Lambda expressions Ex 4")]
    public void LamdaEx4()
    {
        Func<(int, int, int), (int, int, int)> doubleThem =
            ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);
        var numbers = (2, 3, 4);
        var doubledNumbers = doubleThem(numbers);
        Debug.Log($"The set {numbers} doubled: {doubledNumbers}");
    }

    [ContextMenu("Lambda expressions Ex 5")]
    public void LamdaEx5()
    {
        Func<(int n1, int n2, int n3), (int, int, int)> doubleThem =
            ns => (2 * ns.n1, 2 * ns.n2, 2 * ns.n3);
        var numbers = (2, 3, 4);
        var doubledNumbers = doubleThem(numbers);
        Debug.Log($"The set {numbers} doubled: {doubledNumbers}");
    }

    [ContextMenu("Lambda expressions Ex 6")]
    public void LamdaEx6()
    {
        Func<int, bool> equalsFive = x => x == 5;
        bool result = equalsFive(4);
        Debug.Log(result);

        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        int oddNumbers = numbers.Count(n => n % 2 == 1);
        Debug.Log($"There are {oddNumbers} odd numbers in {string.Join(" ", numbers)}");

        var firstNumbersLessThanSix = numbers.TakeWhile(n => n < 6);
        Debug.Log(string.Join(" ", firstNumbersLessThanSix));

        var firstSmallNumbers = numbers.TakeWhile((n, index) => n >= index);
        Debug.Log(string.Join(" ", firstSmallNumbers));

        var numberSets = new List<int[]>
        {
            new[] { 1, 2, 3, 4, 5 },
            new[] { 0, 0, 0 },
            new[] { 9, 8 },
            new[] { 1, 0, 1, 0, 1, 0, 1, 0 }
        };

        var setsWithManyPositives =
            from numberSet in numberSets
            where numberSet.Count(n => n > 0) > 3
            select numberSet;

        foreach (var numberSet in setsWithManyPositives)
        {
            Debug.Log(string.Join(" ", numberSet));
        }
    }
}
