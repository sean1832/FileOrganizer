using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FileOrganizer
{
    public class Utility
    {
        #region public functions

        public static Dictionary<string, string> GetTreeCollection(string configPath)
        {
            Dictionary<string, string> treeCollection = new Dictionary<string, string>();
            List<TreePath> tree = GetTree(configPath);
            foreach (var file in tree)
            {
                treeCollection.Add(file.Extension, file.Path);
            }
            return treeCollection;
        }

        public static string OtherFolder = @"\Other";

        public static string GetNewSubDirectory(string extension)
        {
            string subDir;
            Dictionary<string, string> treeCollection = Utility.GetTreeCollection("TreeConfig.json");

            if (!treeCollection.ContainsKey(extension))
                subDir = Utility.OtherFolder;
            else
                subDir = treeCollection[extension];
            return subDir;
        }

        public static string GetUniquePath(string targetPath)
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


        #region private functions

        private static List<TreePath> GetTree(string path)
        {
            CreateFileIfNotExist(path);

            var tree = JsonConvert.DeserializeObject<List<TreePath>>(File.ReadAllText(path));
            return tree;
        }

        private static void CreateFileIfNotExist(string path)
        {
            if (!IsPathValid(path))
            {
                WriteToExampleFile(path);
                MessageBox.Show($"Error: {path} is empty\nPlease configure .json file with content!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult dr = MessageBox.Show($"Do you want to open config file ({path}) now?", "Open File", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.Yes) Process.Start(path);
                Environment.Exit(0);
            }
        }

        private static bool IsPathValid(string path)
        {
            if (!File.Exists(path)) return false;
            else if (new FileInfo(path).Length == 0) return false;
            else if (File.ReadAllText(path) == GetExampleContent()) return false;
            else return true;
        }

        private static void WriteToExampleFile(string path)
        {
            File.WriteAllText(path, GetExampleContent());
        }

        private static string GetExampleContent()
        {
            var exampleContent = new List<TreePath>
            {
                new TreePath
                {
                    Extension = ".extension type 1",
                    Path = "path1"
                },
                new TreePath
                {
                    Extension = ".extension type 2",
                    Path = "path2"
                }
            };
            var content = JsonConvert.SerializeObject(exampleContent, Formatting.Indented);
            return content;
        }

        #endregion


    }
}