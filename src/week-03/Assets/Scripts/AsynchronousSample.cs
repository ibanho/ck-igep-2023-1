using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AsynchronousSample : MonoBehaviour
{

#region Write text

    #region Simple example
    [ContextMenu("Simple Write Async")]
    public async Task SimpleWriteAsync()
    {
        string filePath = "simple.txt";
        string text = $"Hello World";

        await File.WriteAllTextAsync(filePath, text);
    }
    #endregion Simple example

    #region Finite control example
    public async Task ProcessWriteAsync()
    {
        string filePath = "temp.txt";
        string text = $"Hello World{Environment.NewLine}";

        await WriteTextAsync(filePath, text);
    }

    async Task WriteTextAsync(string filePath, string text)
    {
        byte[] encodedText = Encoding.Unicode.GetBytes(text);

        using var sourceStream =
            new FileStream(
                filePath,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true);

        await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
    }
    #endregion Finite control example

    #endregion

#region Read text

    #region Simple example
    [ContextMenu("Simple Read Async")]
    public async Task SimpleReadAsync()
    {
        string filePath = "simple.txt";
        string text = await File.ReadAllTextAsync(filePath);

        Debug.Log(text);
    }
    #endregion Simple example

    #region Finite control example
    public async Task ProcessReadAsync()
    {
        try
        {
            string filePath = "temp.txt";
            if (File.Exists(filePath) != false)
            {
                string text = await ReadTextAsync(filePath);
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine($"file not found: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    async Task<string> ReadTextAsync(string filePath)
    {
        using var sourceStream =
            new FileStream(
                filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true);

        var sb = new StringBuilder();

        byte[] buffer = new byte[0x1000];
        int numRead;
        while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
        {
            string text = Encoding.Unicode.GetString(buffer, 0, numRead);
            sb.Append(text);
        }

        return sb.ToString();
    }
    #endregion inite control example

#endregion Read text

#region Parallel asynchronous I/O

    #region Simple example
    public async Task SimpleParallelWriteAsync()
    {
        string folder = Directory.CreateDirectory("tempfolder").Name;
        IList<Task> writeTaskList = new List<Task>();

        for (int index = 11; index <= 20; ++index)
        {
            string fileName = $"file-{index:00}.txt";
            string filePath = $"{folder}/{fileName}";
            string text = $"In file {index}{Environment.NewLine}";

            writeTaskList.Add(File.WriteAllTextAsync(filePath, text));
        }

        await Task.WhenAll(writeTaskList);
    }
    #endregion Simple example

    #region Finite control example
    public async Task ProcessMultipleWritesAsync()
    {
        IList<FileStream> sourceStreams = new List<FileStream>();

        try
        {
            string folder = Directory.CreateDirectory("tempfolder").Name;
            IList<Task> writeTaskList = new List<Task>();

            for (int index = 1; index <= 10; ++index)
            {
                string fileName = $"file-{index:00}.txt";
                string filePath = $"{folder}/{fileName}";

                string text = $"In file {index}{Environment.NewLine}";
                byte[] encodedText = Encoding.Unicode.GetBytes(text);

                var sourceStream =
                    new FileStream(
                        filePath,
                        FileMode.Create, FileAccess.Write, FileShare.None,
                        bufferSize: 4096, useAsync: true);

                Task writeTask = sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                sourceStreams.Add(sourceStream);

                writeTaskList.Add(writeTask);
            }

            await Task.WhenAll(writeTaskList);
        }
        finally
        {
            foreach (FileStream sourceStream in sourceStreams)
            {
                sourceStream.Close();
            }
        }
    }
    #endregion Finite control example

#endregion Parallel asynchronous I/O
}
