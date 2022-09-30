using System;
using System.IO;
using System.Windows.Forms;

namespace FileOrganizer
{
    public class Action
    {
        public static void Operation(string cmdVal, string outputPath)
        {
            switch (cmdVal)
            {
                case "--unpack":
                    Action.UnpackFile(outputPath);
                    Console.WriteLine("unpacked");
                    break;
                case "--pack":
                    Action.PackFile(outputPath);
                    Console.WriteLine("packed");
                    break;
                default:
                    MessageBox.Show("Error: operation argument is not entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    break;
            }
        }


        public static void UnpackFile(string rootDir)
        {
            string[] allFiles = Directory.GetFiles(rootDir, ".", SearchOption.AllDirectories);
            foreach (string file in allFiles)
            {
                string fileName = Path.GetFileName(file);

                File.Move(file, $"{rootDir}/{fileName}");
            }
            Directory.Delete($"{rootDir}/Archive", true);
        }

        public static void PackFile(string rootDir)
        {
            string[] files = Directory.GetFiles(rootDir);

            foreach (string filePath in files)
            {
                // extract file name
                string fileName = Path.GetFileName(filePath);

                // compare extension
                string extension = Path.GetExtension(filePath);

                string newSubDir = Utility.GetNewSubDirectory(extension);
                string newRoot = @"Archive";

                string fullNewDir = $"{rootDir}/{newRoot}/{newSubDir}";
                string fullNewPath = $"{fullNewDir}/{fileName}";

                // move to directory according to dictionary path
                Directory.CreateDirectory(fullNewDir);

                // check duplicate
                string outputPath = Utility.GetUniquePath(fullNewPath);

                // move
                Directory.Move(filePath, outputPath);
            }
        }
    }
}