using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> createdFiles = new List<string>();
        int maxFilesToCreate = 5; // maximum number of files to create
        try
        {
            for (int i = 0; i < maxFilesToCreate; i++)
            {
                string path = @"C:\temp\MyTest" + i + ".txt";

                // Ensure that the target does not exist.
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Console.WriteLine($"Deleted existing file: {path}");
                }

                // Create the file.
                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new System.Text.UTF8Encoding(true).GetBytes("This is some text in the file.");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                    Console.WriteLine($"Created new file: {path}");
                }

                // Add the file path to our list of created files.
                createdFiles.Add(path);

                // Open the stream and read it back.
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"Read from file: {s}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Delete all created files
        foreach(string filePath in createdFiles)
        {
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    Console.WriteLine($"Deleted file: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting file {filePath}: {ex.Message}");
                }
            }
        }
        Console.WriteLine("All created files have been deleted");
    }
}
