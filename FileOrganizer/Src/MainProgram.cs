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
            #endregion
        }
    }
}
