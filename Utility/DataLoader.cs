using System;
using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public static class DataLoader
    {
        public static IEnumerable<string> LoadLines(string fileName, string day = "Data")
        {
            var projectRoot = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            var dataPath = Path.Combine(projectRoot, day);
            var path = Path.Combine(dataPath, fileName);
            return File.ReadLines(path);
        }

        public static string LoadAllLines(string fileName, string day = "Data")
        {
            var projectRoot = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName;
            var dataPath = Path.Combine(projectRoot, day);
            var path = Path.Combine(dataPath, fileName);
            return File.ReadAllText(path);
        }

        public static IEnumerable<string> LoadExample(string day = "Data")
        {
            return LoadLines("ExampleInput.txt", day);
        }

        public static string LoadExampleString(string day = "Data")
        {
            return LoadAllLines("test.txt", day);
        }

        public static IEnumerable<string> LoadChallenge(string day = "Data")
        {
            return LoadLines("ActualInput.txt", day);
        }

        public static string LoadChallengeString(string day = "Data")
        {
            return LoadAllLines("challengeInput.txt", day);
        }
    }
}