using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileOrganizer
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
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
                    Action.Operation(cmd, path);
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
        }
    }
}
