using System;
using System.IO;

class Program
{
    static void Main()
    {
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

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            i++;
        }
    }
}
