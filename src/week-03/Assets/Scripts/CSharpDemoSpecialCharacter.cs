using System;
using UnityEngine;

public partial class CSharpDemo : MonoBehaviour
{
    [ContextMenu("String interpolation using $ ex1")]
    public void StringInterpolation1()
    {
        string name = "Mark";
        var date = DateTime.Now;

        // Composite formatting:
        Debug.Log(
            string.Format("Hello, {0}! Today is {1}, it's {2:HH:mm} now.",
                            name, date.DayOfWeek, date));

        // String interpolation:
        Debug.Log($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
    }

    [ContextMenu("String interpolation using $ ex2")]
    public void StringInterpolation2()
    {
        Debug.Log($"|{"Left",-7}|{"Right",7}|");

        const int FieldWidthRightAligned = 20;
        Debug.Log($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
        Debug.Log($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");
    }

    //public void StringInterpolationCSharp11()
    //{
    //    string message = $"The usage policy for {safetyScore} is {
    //    safetyScore switch
    //    {
    //        > 90 => "Unlimited usage",
    //        > 80 => "General usage, with daily safety check",
    //        > 70 => "Issues must be addressed within 1 week",
    //        > 50 => "Issues must be addressed within 1 day",
    //        _ => "Issues must be addressed before continued use",
    //    }}";

    //    int X = 2;
    //    int Y = 3;

    //    var pointMessage = $"""The point "{X}, {Y}" is {Math.Sqrt(X * X + Y * Y)} from the origin""";

    //    Console.WriteLine(pointMessage);
    //    // output:  The point "2, 3" is 3.605551275463989 from the origin.

    //    int X = 2;
    //    int Y = 3;

    //    var pointMessage = $$"""The point {{{X}}, {{Y}}} is {{Math.Sqrt(X * X + Y * Y)}} from the origin""";
    //    Console.WriteLine(pointMessage);
    //    // output:  The point {2, 3} is 3.605551275463989 from the origin.
    //}

    [ContextMenu("String interpolation using $ ex3")]
    public void StringInterpolation3()
    {
        string name = "Horace";
        int age = 34;
        Debug.Log($"He asked, \"Is your name {name}?\", but didn't wait for a reply :-{{");
        Debug.Log($"{name} is {age} year{(age == 1 ? "" : "s")} old.");
    }

    [ContextMenu("String interpolation using $ ex4")]
    public void StringInterpolation4()
    {
        double speedOfLight = 299792.458;
        FormattableString message = $"The speed of light is {speedOfLight:N3} km/s.";

        System.Globalization.CultureInfo.CurrentCulture = 
            System.Globalization.CultureInfo.GetCultureInfo("nl-NL");
        string messageInCurrentCulture = message.ToString();

        var specificCulture = 
            System.Globalization.CultureInfo.GetCultureInfo("en-IN");
        string messageInSpecificCulture = message.ToString(specificCulture);

        string messageInInvariantCulture = FormattableString.Invariant(message);

        Debug.Log($"{System.Globalization.CultureInfo.CurrentCulture,-10} {messageInCurrentCulture}");
        Debug.Log($"{specificCulture,-10} {messageInSpecificCulture}");
        Debug.Log($"{"Invariant",-10} {messageInInvariantCulture}");
    }

    [ContextMenu("Verbatim Text")]
    public void VerbatimText()
    {
        string[] @for = { "John", "James", "Joan", "Jamie" };
        for (int ctr = 0; ctr < @for.Length; ctr++)
        {
            Debug.Log($"Here is your gift, {@for[ctr]}!");
        }

        string filename1 = @"c:\documents\files\u0066.txt";
        string filename2 = "c:\\documents\\files\\u0066.txt";

        Debug.Log(filename1);
        Debug.Log(filename2);


        string s1 = "He said, \"This is the last \u0063hance\x0021\"";
        string s2 = @"He said, ""This is the last \u0063hance\x0021""";

        Debug.Log(s1);
        Debug.Log(s2);
    }

    /// <summary>
    /// C# 11
    /// </summary>
    //public void RawStringLiteralText()
    //{
    //    var singleLine = """This is a "raw string literal". It can contain characters like \, ' and ".""";

    //    var xml = """
    //            <element attr="content">
    //                <body>
    //                </body>
    //            </element>
    //            """;
    //}
}