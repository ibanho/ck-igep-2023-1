using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public partial class CSharpDemo : MonoBehaviour
{
    [ContextMenu("Language Integrated Query Ex1")]
    public void LanguageIntegratedQuery1()
    {
        // Specify the data source.
        int[] scores = { 97, 92, 81, 60 };

        // Define the query expression.
        IEnumerable<int> scoreQuery =
            from score in scores
            where score > 80
            select score;

        // Execute the query.
        foreach (int i in scoreQuery)
        {
            _stringBuilder.Append(i + " ");
        }

        Debug.Log(_stringBuilder.ToString());
        _stringBuilder.Clear();

        IEnumerable<int> highScoresQuery =
            from score in scores
            where score > 80
            orderby score descending
            select score;

        foreach (int i in highScoresQuery)
        {
            _stringBuilder.Append(i + " ");
        }

        Debug.Log(_stringBuilder.ToString());
        _stringBuilder.Clear();

        IEnumerable<string> highScoresQuery2 =
            from score in scores
            where score > 80
            orderby score descending
            select $"The score is {score}";

        foreach (string str in highScoresQuery2)
        {
            Debug.Log(str);
        }

        int highScoreCount = (
            from score in scores
            where score > 80
            select score
        ).Count();
        Debug.Log(highScoreCount);

        IEnumerable<int> highScoresQuery3 =
            from score in scores
            where score > 80
            select score;
        int scoreCount = highScoresQuery3.Count();
        Debug.Log(scoreCount);
    }

    [ContextMenu("Language Integrated Query Ex2")]
    public void LanguageIntegratedQuery2()
    {
        //
        // Example - Query syntax
        //

        List<int> numbers = new() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        // The query variables can also be implicitly typed by using var

        // Query #1.
        IEnumerable<int> filteringQuery =
            from num in numbers
            where num < 3 || num > 7
            select num;

        // Query #2.
        IEnumerable<int> orderingQuery =
            from num in numbers
            where num < 3 || num > 7
            orderby num ascending
            select num;

        // Query #3.
        string[] groupingQuery = { "carrots", "cabbage", "broccoli", "beans", "barley" };
        IEnumerable<IGrouping<char, string>> queryFoodGroups =
            from item in groupingQuery
            group item by item[0];

        //
        // Example - Method syntax
        //

        List<int> numbers1 = new() { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        List<int> numbers2 = new() { 15, 14, 11, 13, 19, 18, 16, 17, 12, 10 };

        // Query #4.
        double average = numbers1.Average();

        // Query #5.
        IEnumerable<int> concatenationQuery = numbers1.Concat(numbers2);

        // Query #6.
        IEnumerable<int> largeNumbersQuery = numbers2.Where(c => c > 15);

        // var is used for convenience in these queries
        var average2 = numbers1.Average();
        var concatenationQuery2 = numbers1.Concat(numbers2);
        var largeNumbersQuery2 = numbers2.Where(c => c > 15);

        //
        // Example - Mixed query and method syntax
        //

        // Query #7.

        // Using a query expression with method syntax
        int numCount1 = (
            from num in numbers1
            where num < 3 || num > 7
            select num
        ).Count();

        // Better: Create a new variable to store
        // the method call result
        IEnumerable<int> numbersQuery =
            from num in numbers1
            where num < 3 || num > 7
            select num;

        int numCount2 = numbersQuery.Count();

        var numCount = numbers.Where(n => n < 3 || n > 7).Count();
        //int numCount = numbers.Where(n => n < 3 || n > 7).Count();
    }
}
