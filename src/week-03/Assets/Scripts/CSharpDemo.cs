using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public partial class CSharpDemo : MonoBehaviour
{
    public void ArrayEx()
    {
        /// 3x3x3 배열 선언과 사용
        int[,,] array333 = new int[3, 3, 3];

        array333[0, 0, 0] = 3;

        // 3x2x3 배열 선언과 동시에 초기화
        int[,,] array323 = new int[,,]
        {
            {
                {111, 112},
                {121, 122}
            },
            {
                {211, 212},
                {221, 222}
            },
            {
                {311, 312},
                {321, 322}
            },
        };

        // 3x3 가변 배열의 선언
        int[][] jaggedArray = new int[3][];

        jaggedArray[0] = new int[3];
        jaggedArray[1] = new int[3];
        jaggedArray[2] = new int[3];

        // 가변 배열의 특성
        int[][] jaggedArray2 = new int[3][];

        jaggedArray2[0] = new int[5];
        jaggedArray2[1] = new int[4];
        jaggedArray2[2] = new int[9];

        // 가변 배열의 초기화
        int[][] jaggedArray3 = new int[3][];

        jaggedArray3[0] = new int[] { 11, 12, 13 };
        jaggedArray3[1] = new int[] { 22, 23, 24, 25 };
        jaggedArray3[2] = new int[] { 31, 32 };

        int[][,] jaggedArray4 = new int[3][,]
        {
            new int[,] {{1, 3}, {5, 7} },
            new int[,] {{0, 2}, {4, 6}, {9, 10}},
            new int[,] {{11, 22}, {99, 88}, {0, 9}}
        };
    }

    public void NullableEx()
    {
        double? pi = 3.14;
        char? letter = 'a';

        int m2 = 10;
        int? m = m2;

        bool? flag = null;

        int?[] arr = new int?[10];
    }

    public void BoxingUnBoxing()
    {
        int i = 123;
        object o = i;   // boxing
        int j = (int)o; // unboxing
    }

    [ContextMenu("checked op")]
    public void Checked()
    {
        int a = 1000000;
        int b = 1000000;

        int c = checked(a * b);

        checked
        {
            c = a * b;
        }
    }

    [ContextMenu("unchecked op")]
    public void Unchecked()
    {
        int x = int.MaxValue;
        int y = unchecked(x + 1);
        Debug.Log(y);

        unchecked
        {
            int z = x + 1;
            Debug.Log(z);
        }

        //int m = int.MaxValue + 1;
        int n = unchecked(int.MaxValue + 1);
    }

    [ContextMenu("params keyword")]
    public void CallParams()
    {
        UseParams(1, 2, 3, 4);
        UseParams2(.1, .2, .4, .5);
    }

    public static void UseParams(params int[] list)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < list.Length; i++)
        {
            stringBuilder.Append($"{list[i]} ");
        }
        Debug.Log(stringBuilder.ToString());
    }

    public static void UseParams2(params object[] list)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < list.Length; i++)
        {
            stringBuilder.Append($"{list[i]} ");
        }
        Debug.Log(stringBuilder.ToString());
    }

    [ContextMenu("loop")]
    public void LoopEx()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(i);
        }

        var fibNumbers = new List<int> { 0, 1, 1, 2, 3, 4, 5, 13 };
        foreach (int i in fibNumbers)
        {
            Debug.Log(i);
        }

        // c# 7.3
        Span<int> storage = stackalloc int[10];
        int num = 0;
        foreach (ref int item in storage)
        {
            item = num++;
        }

        foreach (ref readonly var item in storage)
        {
            Debug.Log(item);
        }
    }

    public static async IAsyncEnumerable<int> GenerateSequence()
    {
        for (int i = 0; i < 20; i++)
        {
            await Task.Delay(100);
            yield return i;
        }
    }

    static async Task LoopEx2(string[] args)
    {
        await foreach (var number in GenerateSequence())
        {
            Debug.Log(number);
        }
    }

    public void LoopEx3()
    {
        int n = 0;

        // do - while
        do
        {
            Debug.Log(n);
            n++;
        } while (n < 5);

        // while
        while (n > 0)
        {
            Debug.Log(n);
            n--;
        }
    }
}
