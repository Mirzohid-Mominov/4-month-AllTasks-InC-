using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_N55_HT
{
    //    N55-HT1

    //- Console application yarating
    //- asosiy project build papkasi ichiga(bin/Debug/.net7 ) bir nechta folder va filelar copy qiling
    //- asosiy project papkasi ichida nechta folder va fayl borligini
    //- fayllar umumiy hajmi(size ) va eng katta fayl qaysi ekanligini qaytaradigan service va methodlar yozing(nomlarini o'zingiz o'ylab ko'ring ) 
    //- tepada aytilgan ma'lumotlarni ekranga chiqaring
    public static class Paths
    {
        public static void Execute()
        {
            var appFolder = Directory.GetCurrentDirectory();

            var folderName = "filessssssss";
            var createdFolder = Path.Combine(appFolder, folderName);
            Directory.CreateDirectory(createdFolder);

            var txtFileName = "filessssssss.txt1";
            File.CreateText(txtFileName);

            var fileName = "hello.exe";
            var createdFile = Path.Combine(appFolder, fileName);
            Directory.CreateDirectory(createdFile);

            var jsonFileName = "file.json";
            var createdJsonFile = Path.Combine(appFolder, jsonFileName);
            Directory.CreateDirectory(createdJsonFile);

            var filePath = "3456789";
            using var createdFile1 = File.Create(filePath, 2);

            Console.WriteLine("hello");
        }

        public static void FindAllEntries(string path)
        {
            var countOfEntries = Directory.GetFileSystemEntries(path).Length;
            Console.WriteLine(countOfEntries);
        }

        public static void SumOfAllFiles(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            var totalSize = directoryInfo.GetFiles("*", SearchOption.AllDirectories).Sum(file => file.Length);
            Console.WriteLine(totalSize);
        }

        public static void FindMaxFile(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            var maxFile = directoryInfo.GetFiles("*", SearchOption.AllDirectories).Max(file => file.Length);
            Console.WriteLine(maxFile);
        }
    }
}