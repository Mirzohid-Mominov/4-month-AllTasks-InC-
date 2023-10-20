namespace SearchEntries.Services
{
    public class Searching
    {
        public string SearchDirectoryName(string fileName)
        {
            var directory = Directory.GetDirectories(@"D:\\", "*", SearchOption.TopDirectoryOnly);

            for (var item = 0; item < directory.Length; item++)
            {
                var foundFile = SearchFileName(directory[item], fileName);
                if (foundFile != null)
                    return foundFile;

            }
                return "There isn't this file";
        }

        public string SearchFileName(string path, string fileName)
        {
            var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
            return files.FirstOrDefault(x => Path.GetFileName(x).Equals(fileName));
        }
    }
}