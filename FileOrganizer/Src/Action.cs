using System.IO;

namespace FileOrganizer
{
    public class Action
    {
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