using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Initialize file count and total bytes written
        int fileCount = 0;
        long totalBytesWritten = 0;

        // Path to the MessageBoxPlugin and AnalyticsPlugin
        string messageBoxPluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugin_Wizard.exe");
        string analyticsPluginPath = Path.Combine(Directory.GetCurrentDirectory(), "Plugin_Analytics.exe");

        if (File.Exists(messageBoxPluginPath))
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(messageBoxPluginPath);
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

                            // Update total bytes written
                            totalBytesWritten += info.Length;
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

                        // Update file count
                        fileCount++;
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
            Console.WriteLine("MessageBoxPlugin not found. Running the program without user confirmation...");
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

                    // Update total bytes written
                    totalBytesWritten += info.Length;
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

                // Update file count
                fileCount++;
            }
        }

        // Run AnalyticsPlugin
        if (File.Exists(analyticsPluginPath))
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(analyticsPluginPath);
                startInfo.UseShellExecute = false;
                startInfo.Arguments = $"{fileCount} {totalBytesWritten}"; // Pass file count and total bytes written as arguments
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting AnalyticsPlugin: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("AnalyticsPlugin not found. Exiting without running analytics...");
        }
    }
}
