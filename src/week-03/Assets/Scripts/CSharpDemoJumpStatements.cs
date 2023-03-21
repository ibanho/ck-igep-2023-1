using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public partial class CSharpDemo : MonoBehaviour
{
    private StringBuilder _stringBuilder = new StringBuilder();

    [ContextMenu("The break statement 1")]
    public void BreakStatement()
    {
        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        foreach (int number in numbers)
        {
            if (number == 3)
            {
                break;
            }

            _stringBuilder.Append($"{number} ");
        }
        Debug.Log(_stringBuilder.ToString());
        Debug.Log("End of the example.");

        _stringBuilder.Clear();
    }

    [ContextMenu("The break statement 2")]
    public void BreakStatement2()
    {
        for (int outer = 0; outer < 5; outer++)
        {
            for (int inner = 0; inner < 5; inner++)
            {
                if (inner > outer)
                {
                    break;
                }

                _stringBuilder.Append($"{inner} ");
            }
            Debug.Log(_stringBuilder.ToString());
            _stringBuilder.Clear();
        }
    }

    [ContextMenu("The break statement 3")]
    public void BreakStatement3()
    {
        double[] measurements = { -4, 5, 30, double.NaN };
        foreach (double measurement in measurements)
        {
            switch (measurement)
            {
                case < 0.0:
                    Debug.Log($"Measured value is {measurement}; too low.");
                    break;

                case > 15.0:
                    Debug.Log($"Measured value is {measurement}; too high.");
                    break;

                case double.NaN:
                    Debug.Log("Failed measurement.");
                    break;

                default:
                    Debug.Log($"Measured value is {measurement}.");
                    break;
            }
        }
    }

    [ContextMenu("The continue statement")]
    public void ContinueStatement()
    {
        for (int i = 0; i < 5; i++)
        {
            _stringBuilder.Append($"Iteration {i}: ");
            
            if (i < 3)
            {
                _stringBuilder.Append("skip");
                Debug.Log(_stringBuilder.ToString());
                _stringBuilder.Clear();
                continue;
            }

            _stringBuilder.Append("done");
            Debug.Log(_stringBuilder.ToString());
            _stringBuilder.Clear();
        }
    }

    [ContextMenu("The return statement 1")]
    public void ReturnStatement1()
    {
        Debug.Log("First call:");
        DisplayIfNecessary(6);

        Debug.Log("Second call:");
        DisplayIfNecessary(5);
    }

    void DisplayIfNecessary(int number)
    {
        if (number % 2 == 0)
        {
            return;
        }

        Debug.Log(number);
    }

    [ContextMenu("The return statement 2")]
    public void ReturnStatement2()
    {
        double surfaceArea = CalculateCylinderSurfaceArea(1, 1);
        Debug.Log($"{surfaceArea:F2}"); // output: 12.57

        double CalculateCylinderSurfaceArea(double baseRadius, double height)
        {
            double baseArea = Math.PI * baseRadius * baseRadius;
            double sideArea = 2 * Math.PI * baseRadius * height;
            return 2 * baseArea + sideArea;
        }
    }
}
