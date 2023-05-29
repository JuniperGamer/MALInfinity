using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "MessageBoxPlugin.exe");
        if (File.Exists(pluginPath))
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(pluginPath);
                startInfo.UseShellExecute = false;
                Process pluginProcess = Process.Start(startInfo);
                pluginProcess.WaitForExit();

                // Check the exit code of the plugin
                if (pluginProcess.ExitCode == 1)
                {
                    Console.WriteLine("User agreed to proceed. Running the rest of the program...");
                    int i = 0;
                    while (true)
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
                else
                {
                    Console.WriteLine("User did not agree to proceed. Exiting program...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting plugin: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Plugin not found. Running the program without user confirmation...");
            int i = 0;
            while (true)
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
}
