using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FileName_Append
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program ctx = new Program();
            //ctx.AppendToFileNames();

            Console.WriteLine("Folders or files? " +
                "\n 1. Files" +
                "\n 2. Folders" +
                "\n 3. Close");
            char input = Console.ReadKey(true).KeyChar;
            Console.WriteLine("\n \n");
            switch (input)
            {
                case '1':
                    ctx.AppendToFileNames();
                    break;
                case '2':
                    ctx.RemoveFromFolderName();
                    break;
                case '3':
                    break;
                default:
                    Console.WriteLine("invalid input");
                    Console.ReadKey();
                    Console.Clear();
                    Main(args);
                    break;
            }






        }

        public void AppendToFileNames()
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

            Reset();
        }

        public void RemoveFromFolderName()
        {
            Console.WriteLine("Please input directory address: ");
            string directory = Console.ReadLine();
            List<string> files = Directory.GetDirectories(directory).ToList();
            files.ForEach(file => Console.WriteLine(file));

            Console.WriteLine("What would you like to remove from these folder names?");
            string toBeRemoved = Console.ReadLine();

            files.ForEach(file =>
            {
                DirectoryInfo info = new DirectoryInfo(file);
                Console.WriteLine(file.Replace(toBeRemoved, ""));
                //Directory.Move(file, file.Replace("", ""));
                info.MoveTo(file.Replace(toBeRemoved, ""));
            });

            Console.WriteLine("//////////////");
            List<string> newFiles = Directory.GetDirectories(directory).ToList();
            newFiles.ForEach(file => Console.WriteLine(file));

            Reset();
        }
        public void Reset()
        {
            Console.WriteLine(  "press any button to continue...");
            var input = Console.ReadKey();
            Console.Clear();
            string[] args = new string[] { };
            Main(args);
        }
    }
}
