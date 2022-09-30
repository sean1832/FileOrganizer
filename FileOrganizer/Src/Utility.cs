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
        
        public static List<TreePath> GetTree(string path)
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

    }
}