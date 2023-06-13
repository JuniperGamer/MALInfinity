using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int numberOfFiles = Convert.ToInt32(args[0]); // Get the number of files created from command line arguments
        long totalBytesWritten = Convert.ToInt64(args[1]); // Get the total bytes written from command line arguments

        // Calculate some analytics
        double averageFileSize = (double)totalBytesWritten / numberOfFiles;

        // Print the analytics
        Console.WriteLine($"Number of files created: {numberOfFiles}");
        Console.WriteLine($"Total data written: {totalBytesWritten} bytes");
        Console.WriteLine($"Average file size: {averageFileSize} bytes");
    }
}
