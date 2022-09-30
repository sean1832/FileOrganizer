using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FileOrganizer
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            #region Debug & Test Zone

            //UnpackFile(@"E:\test");

            #endregion

            #region main Logic
            string path = args.FirstOrDefault();
            string cmd = null;
            if (args.Length == 2)
            {
                cmd = args[1];
            }


            if (path != null)
            {
                if (Directory.Exists(path))
                {
                    Operation(cmd, path);
                }
                else
                {
                    DialogResult dr = MessageBox.Show($"Warning: argument path {path} does not exist\nDo you want to create a directory?",
                        "Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);

                    if (dr == DialogResult.No) Environment.Exit(0);
                    else
                    {
                        Directory.CreateDirectory(path);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: No argument detected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            #endregion

            #region Local Functions

            void Operation(string cmdVal, string outputPath)
            {
                switch (cmdVal)
                {
                    case "--unpack":
                        UnpackFile(outputPath);
                        Console.WriteLine("unpacked");
                        break;
                    case "--pack":
                        PackFile(outputPath);
                        Console.WriteLine("packed");
                        break;
                    default:
                        MessageBox.Show("Error: operation argument is not entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                        break;
                }
            }

            void UnpackFile(string rootDir)
            {
                string[] allFiles = Directory.GetFiles(rootDir, ".", SearchOption.AllDirectories);
                foreach (string file in allFiles)
                {
                    string fileName = Path.GetFileName(file);

                    File.Move(file, $"{rootDir}/{fileName}");
                }

                Directory.Delete($"{rootDir}/Archive", true);
            }



            void PackFile(string rootDir)
            {
                string[] files = Directory.GetFiles(rootDir);

                foreach (string filePath in files)
                {
                    // extract file name
                    string fileName = Path.GetFileName(filePath);

                    // compare extension
                    string extension = Path.GetExtension(filePath);

                    string newSubDir = GetNewSubDirectory(extension);
                    string newRoot = @"Archive";

                    string fullNewDir = $"{rootDir}/{newRoot}/{newSubDir}";
                    string fullNewPath = $"{fullNewDir}/{fileName}";

                    // move to directory according to dictionary path
                    Directory.CreateDirectory(fullNewDir);

                    // check duplicate
                    string outputPath = GetUniquePath(fullNewPath);

                    // move
                    Directory.Move(filePath, outputPath);
                }
            }


            string GetNewSubDirectory(string extension)
            {
                string subDir;
                Dictionary<string, string> treeCollection = Utility.GetTreeCollection("TreeConfig.json");

                if (!treeCollection.ContainsKey(extension)) 
                    subDir = Utility.OtherFolder;
                else 
                    subDir = treeCollection[extension];
                return subDir;
            }

            string GetUniquePath(string targetPath)
            {
                int count = 1;

                string extension = Path.GetExtension(targetPath);
                string targetDir = Path.GetDirectoryName(targetPath);
                string outputPath = targetPath;
                string existingFileName = Path.GetFileNameWithoutExtension(targetPath);

                while (File.Exists(outputPath))
                {
                    string tempFileName = $"{existingFileName} ({count++})";
                    outputPath = $"{targetDir}/{tempFileName}{extension}";
                }
                return outputPath;
            }
            
            #endregion
            
        }
    }
}
