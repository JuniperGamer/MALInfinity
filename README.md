# Educational File Manipulation Program
This repository contains a simple C# console application that demonstrates basic file interaction. It is intended for educational purposes only, to help users understand how certain types of malware might interact with files.

Please note that this application, while harmless in its current form, could potentially be used as a basis for harmful software. It should not be used for any malicious purposes, and the creators of this repository are not responsible for any misuse of the code.

### About the Program
The application works by creating a series of text files, writing some text to them, and then reading the text back. In its default mode, it will create up to five files and then stop.

There are 3 versions of the Malware:
- Safezone - Completely harmless, creates max of 5 files that can be changed with a debug mode. User Error handling and much more saftey features for testing.
- Eclipse - Mediocre harmfulness. Creates unlimited files but deletes them after closing the program **NOT GUARENTEED TO DELETE THE FILES**
- Ector - True Malware form. Creates unlimited files taking up all of computer's hard drive. Supports Official plugins.

### Usage
To run the program, compile it using a C# compiler, and then run the resulting executable from the command line.

The program will create a series of text files in the C:\temp\ directory (make sure this directory exists), write some text to them, and then read it back. It will also print out information about what it's doing.

After creating the files, the program will automatically delete them.

### Debugging
The Safezone (and Eclipse i think?) includes a "debug mode" that restricts its actions and provides additional output. To enable debug mode, set the maxFilesToCreate variable to the desired maximum number of files.

In debug mode, the program will print out additional information about what it's doing, which can be helpful for understanding its behaviour.

### Safety Precautions
Always be careful when working with Malware examples, especially if you are debugging them. Make sure to back up any important data before running the program, and only run the program in a safe environment.
