using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MessFile
{
    class Worker
    {
        public Worker(string fileName, int limitation)
        {
            FileName = fileName;
            Limitation = limitation;
            FileContent = ReadFile();
            FillCharEntries();
        }

        public string FileName { get; }
        public int Limitation { get; set; }
        public string FileContent { get; }
        public Dictionary<char, int> CharEntries { get; } = new Dictionary<char, int>();

        private string ReadFile()
            => File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), FileName));

        private void FillCharEntries()
            => FileContent?.ToCharArray().Distinct().ToList()
                .ForEach(x => CharEntries.Add(x, FileContent.Count(y => y == x)));

        public string GetCleanText()
        {
            var toDelete = CharEntries.Where(x => x.Value > Limitation).Select(x => x.Key).ToArray();

            return string.Join(string.Empty, FileContent.Split(toDelete));
        }
    }
}
