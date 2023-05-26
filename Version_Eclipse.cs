using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> createdFiles = new List<string>();
        int i = 0;
        while(true)
        {
            string path = @"C:\temp\MyTest" + i + ".txt";

            // Ensure that the target does not exist.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Create the file.
            using (FileStream fs = File.Create(path))
            {
                Byte[] info = new System.Text.UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            // Add the file path to our list of created files.
            createdFiles.Add(path);

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            
            Console.WriteLine("Press 'd' to stop and delete files, any other key to continue");
            if(Console.ReadKey().KeyChar == 'd')
            {
                break;
            }

            i++;
        }

        // User pressed 'd', so delete all created files
        foreach(string filePath in createdFiles)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        Console.WriteLine("All created files have been deleted");
    }
}
