using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Help you to better test dotnet console apps 
/// by providing all lines which will be read from user at runtime, 
/// and all lines which will be written to user at runtime 
/// then validate the actual lines written by the program by the expected one
/// </summary>
public static class FakeConsole
{
    /// <summary>
    /// Paste the text which should be splitted by lines at runtime, to be used in FakeConsole.ReadLine 
    /// </summary>
    public static string ReadLines  = @"";


    /// <summary>
    /// Paste the text which should be splitted by lines at runtime, to compare it with the ones written through FakeConsole.WriteLine
    /// </summary>
    public static string ExpectedWriteLines = @"";






    /// <summary>
    /// Reads next line from the ones set at <see cref="ReadLines"/> 
    /// </summary>
    /// <returns></returns>
    public static string ReadLine()
    {
        if (_readLinesQueue == null)
        {
            _readLinesQueue = new Queue<string>();
            var lines = ReadLines.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (var line in lines)
                _readLinesQueue.Enqueue(line);
        }
        return _readLinesQueue.Dequeue();
    }

    /// <summary>
    /// Store the passed line in <see cref="FakeConsole"/>, then emit it to <see cref="System.Console.WriteLine"/>
    /// </summary>
    /// <param name="line"></param>
    public static void WriteLine(object line)
    {
        _writeLines.Add(line.ToString());
        System.Console.WriteLine(line);
    }


    /// <summary>
    /// Compares expected lines with the actual ones written at runtime 
    /// </summary>
    /// <returns></returns>
    public static bool Validate()
    {
        var expectedLines = ExpectedWriteLines.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

        if (_writeLines.Count != expectedLines.Length)
            return false;


        bool isValid = true;
        for (var i = 0; i < _writeLines.Count; i++)
            isValid &= _writeLines[i] == expectedLines[i];
        return isValid;
    }


    static List<string> _writeLines = new List<string>();
    static Queue<string> _readLinesQueue = null;
}


