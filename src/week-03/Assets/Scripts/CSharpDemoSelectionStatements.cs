using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CSharpDemo : MonoBehaviour
{
    public void SelectionStatements1()
    {
        DisplayWeatherReport(15.0);
        DisplayWeatherReport(24.0);
    }

    void DisplayWeatherReport(double tempInCelsius)
    {
        if (tempInCelsius < 20.0)
        {
            Debug.Log("Cold.");
        }
        else
        {
            Debug.Log("Perfect!");
        }
    }

    public void SelectionStatements2()
    {
        DisplayMeasurement(45);
        DisplayMeasurement(-3);
    }

    void DisplayMeasurement(double value)
    {
        if (value < 0 || value > 100)
        {
            Debug.Log("Warning: not acceptable value! ");
        }

        Debug.Log($"The measurement value is {value}");
    }

    public void SelectionStatements3()
    {
        DisplayCharacter('f');
        DisplayCharacter('R');
        DisplayCharacter('8');
        DisplayCharacter(',');
    }

    void DisplayCharacter(char ch)
    {
        if (char.IsUpper(ch))
        {
            Debug.Log($"An uppercase letter: {ch}");
        }
        else if (char.IsLower(ch))
        {
            Debug.Log($"A lowercase letter: {ch}");
        }
        else if (char.IsDigit(ch))
        {
            Debug.Log($"A digit: {ch}");
        }
        else
        {
            Debug.Log($"Not alphanumeric character: {ch}");
        }
    }

    public void SelectionStatements4()
    {
        DisplayMeasurement2(-4);
        DisplayMeasurement2(5);
        DisplayMeasurement2(30);
        DisplayMeasurement2(double.NaN);
    }

    void DisplayMeasurement2(double measurement)
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

    public void SelectionStatements5()
    {
        DisplayMeasurement3(-4);
        DisplayMeasurement3(50);
        DisplayMeasurement3(132);
    }

    void DisplayMeasurement3(int measurement)
    {
        switch (measurement)
        {
            case < 0:
            case > 100:
                Debug.Log($"Measured value is {measurement}; out of an acceptable range.");
                break;

            default:
                Debug.Log($"Measured value is {measurement}.");
                break;
        }
    }

    public void SelectionStatements6()
    {
        DisplayMeasurements4(3, 4);
        DisplayMeasurements4(5, 5);
    }

    void DisplayMeasurements4(int a, int b)
    {
        // Case guards
        // A case guard must be a Boolean expression.
        switch ((a, b))
        {
            case ( > 0, > 0) when a == b:
                Debug.Log($"Both measurements are valid and equal to {a}.");
                break;

            case ( > 0, > 0):
                Debug.Log($"First measurement is {a}, second measurement is {b}.");
                break;

            default:
                Debug.Log("One or both measurements are not valid.");
                break;
        }
    }
}