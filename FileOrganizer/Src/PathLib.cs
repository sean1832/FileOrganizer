using System.Collections.Generic;
using System.Security.Policy;

namespace FileOrganizer
{
    public static class PathLib
    {
        
        public static Dictionary<string, string> GetTreeCollection(string configPath)
        {
            Dictionary<string, string> treeCollection = new Dictionary<string, string>();
            List<TreePath> tree = Utility.GetTree(configPath);
            foreach (var file in tree)
            {
                treeCollection.Add(file.Extension, file.Path);
            }
            return treeCollection;
        }
        

        public static string OtherFolder = @"\Other";
    }
}