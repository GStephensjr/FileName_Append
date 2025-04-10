using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileName_Append
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please input directory address: ");
            string directory = Console.ReadLine();
            List<string> files = Directory.GetFiles(directory).ToList();
            files.ForEach(file => Console.WriteLine(file));

            Console.WriteLine("What would you like to append to these filenames?");
            string appendage = Console.ReadLine();

            files.ForEach(file =>
            {
                FileInfo currentFile = new FileInfo(file);
                currentFile.MoveTo(currentFile.Directory.FullName + "\\" + Path.GetFileNameWithoutExtension(file) + " - " + appendage + currentFile.Extension);
            });

            Console.WriteLine("//////////////");
            List<string> newFiles = Directory.GetFiles(directory).ToList();
            newFiles.ForEach(file => Console.WriteLine(file));
        }
    }
}
