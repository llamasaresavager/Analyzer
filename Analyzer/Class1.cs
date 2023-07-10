using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string repoPath = @"C:\Users\localadmin\Desktop\Projects\Code Base Analyzer\Deca.Voice";
        string outputFolderPath = @"C:\Users\localadmin\Desktop\Projects\Code Base Analyzer";

        SaveFolderStructureAsJson(repoPath, Path.Combine(outputFolderPath, "repo_structure.json"));
    }

    static void SaveFolderStructureAsJson(string path, string outputFile)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);

        var structure = GetDirectoryStructure(directoryInfo);

        string json = JsonSerializer.Serialize(structure);

        File.WriteAllText(outputFile, json);
    }

    static DirectoryData GetDirectoryStructure(DirectoryInfo directoryInfo)
    {
        if (directoryInfo.Name.Equals("bin", StringComparison.OrdinalIgnoreCase) || directoryInfo.Name.Equals("obj", StringComparison.OrdinalIgnoreCase))
            return null;

        var directoryData = new DirectoryData
        {
            Name = directoryInfo.Name,
            Files = directoryInfo.GetFiles().Where(f => !IsExcluded(f.FullName)).Select(f => f.Name).ToList(),
            Subdirectories = directoryInfo.GetDirectories().Where(d => !IsExcluded(d.FullName)).Select(d => GetDirectoryStructure(d)).Where(d => d != null).ToList()
        };

        return directoryData;
    }

    static bool IsExcluded(string path)
    {
        return path.Split(Path.DirectorySeparatorChar).Any(part => part.Equals("bin", StringComparison.OrdinalIgnoreCase) || part.Equals("obj", StringComparison.OrdinalIgnoreCase));
    }

    class DirectoryData
    {
        public string Name { get; set; }
        public List<string> Files { get; set; }
        public List<DirectoryData> Subdirectories { get; set; }
    }
}
