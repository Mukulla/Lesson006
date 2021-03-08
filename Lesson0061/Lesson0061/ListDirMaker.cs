using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lesson0061
{
    class ListDirMaker
    {
        static public void LaunchDirWriters()
        {
            Console.WriteLine("Введите полный путь до папки, содержимое которой необходимо отобразить");
            //string SomePath = @"C:\Git\Lessons\Lesson001";
            string SomePath = Console.ReadLine();

            //Console.WriteLine("Введите полный путь файла, в который необходимо сохранить дерево содержимого каталога");
            string SavePathIter = @"DirsIter.txt";
            string SavePathRec = @"DirsRec.txt";
            //string SavePath = Console.ReadLine();

            ShowDirIter(SomePath, SavePathIter);
            Console.WriteLine("Содержимое файла с деревом созданным итерационно");
            ShowFile(SavePathIter);
            
            StartRec(SomePath, SavePathRec);
            Console.WriteLine("Содержимое файла с деревом созданным рекурсивно");            
            ShowFile(SavePathRec);
        }
        static void ShowDirIter(string SomePath001, string SavePath001)
        {
            if(!Directory.Exists(SomePath001))
            {
                Console.WriteLine("Такого каталога нет");
                return;
            }
            if(File.Exists(SavePath001))
            {
                File.Delete(SavePath001);
            }
            
            List<string> ListDire = new List<string> { SomePath001 };
            HashSet<string> TotalList = new HashSet<string> { };
            Stack<List<string>> TotalStack = new Stack<List<string>> { };

            while (ListDire.Count > 0)
            {
                string CurrentDir = ListDire[ListDire.Count - 1]; 
                ListDire.RemoveAt(ListDire.Count - 1);                
                ListDire.AddRange(Directory.EnumerateDirectories(CurrentDir));
                TotalList.Add(CurrentDir);               
            }            

            string[] RootElements = SomePath001.Split('\\');
            foreach (var Dire in TotalList)
            {
                string[] Tempo = Dire.Split('\\');                
                string Spaces = FillString("| ", Tempo.Length - RootElements.Length);
                File.AppendAllText(SavePath001, Spaces + Tempo[Tempo.Length - 1] + Environment.NewLine);

                WriteListInFile(Spaces, Dire, SavePath001);                
            }
        }
        static string FillString(string SomeString, int Count)
        {
            string Tempo = "";
            for (int i = 0; i < Count; ++i)
            {
                Tempo += SomeString;
            }
            return Tempo;
        }

        static void ShowFile(string PathFile)
        {
            string FileContent = File.ReadAllText(PathFile);
            Console.WriteLine(FileContent);
        }

        static void StartRec(string SomePath001, string SavePath001)
        {
            if (!Directory.Exists(SomePath001))
            {
                Console.WriteLine("Такого каталога нет");
                return;
            }
            if (File.Exists(SavePath001))
            {
                File.Delete(SavePath001);
            }
            ShowDirRec(SomePath001, SavePath001, 0);
        }

        static void ShowDirRec(string SomePath, string SavePath001, int Level)
        {
            string Shifter = FillString("| ", Level);
            string[] SomeDir = Directory.GetDirectories(SomePath);
            
            for (int i = 0; i < SomeDir.Length; ++i)
            {
                DirectoryInfo DName = new DirectoryInfo(SomeDir[i]);

                //Console.WriteLine(Shifter + DName.Name);
                File.AppendAllText(SavePath001, Shifter + DName.Name + Environment.NewLine);
                ShowDirRec(SomeDir[i], SavePath001, Level + 1);                
            }

            if (SomeDir.Length < 1)
            {
                Shifter = FillString("| ", Level - 1);
            }

            WriteListInFile(Shifter, SomePath, SavePath001);            
        }

        static void WriteListInFile(string Shifter, string SomeDir, string SavePath002)
        {
            string FileSpaces;
            List<string> ListFile = new List<string> { };
            ListFile.AddRange(Directory.EnumerateFiles(SomeDir));
            foreach (var CurrentFile in ListFile)
            {
                string FileName = Path.GetFileName(CurrentFile);
                //TotalList.Add(Path.GetDirectoryName(Item)); 
                //Console.WriteLine(Spaces + FileName);
                //File.AppendAllText(SavePath, Spaces + FileName + Environment.NewLine);
                if (CurrentFile == ListFile.Last())
                {
                    FileSpaces = Shifter + "└──";
                    File.AppendAllText(SavePath002, FileSpaces + FileName + Environment.NewLine);
                }
                else
                {
                    FileSpaces = Shifter + "├──";
                    File.AppendAllText(SavePath002, FileSpaces + FileName + Environment.NewLine);
                }
            }
        }
    }    
}
