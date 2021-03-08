using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lesson006
{
    class ListDirMaker
    {
        static void LaunchDirWriters(string SomePath, string SavePath)
        {
            ShowDirIter(SomePath, SavePath);
        }
        static public void ShowDirIter(string SomePath001, string SavePath001)
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
            Stack<string> TotalStack = new Stack<string> { };

            while (ListDire.Count > 0)
            {
                string CurrentDir = ListDire[ListDire.Count - 1]; 
                ListDire.RemoveAt(ListDire.Count - 1);

                //Console.WriteLine(Path.GetDirectoryName(CurrentDir));
                //File.AppendAllText(SaveDir, CurrentDir + Environment.NewLine);
                ListDire.AddRange(Directory.EnumerateDirectories(CurrentDir));

                //CurrentDir = Path.GetDirectoryName(CurrentDir);
                //Console.WriteLine(CurrentDir);

                //TotalList.Add(CurrentDir);
                TotalStack.Push(CurrentDir);
            }

            foreach (var Dir in TotalStack)
            {
                TotalList.Add(Dir);                
            }
           
            string[] RootElements = SomePath001.Split('\\');
            foreach (var Dire in TotalList.Reverse())
            {                

                string[] Tempo = Dire.Split('\\');
                //File.AppendAllText(SavePath, Item + Environment.NewLine);
                //File.AppendAllText(SavePath, Item + Environment.NewLine);
                //string Spaces = new string(' ', Tempo.Length - RootElements.Length);
                string Spaces = FillString("| ", Tempo.Length - RootElements.Length);
                //Console.WriteLine(Spaces + Tempo[Tempo.Length - 1]);
                File.AppendAllText(SomePath001, Spaces + Tempo[Tempo.Length - 1] + Environment.NewLine);
                
                string FileSpaces;
                List<string> ListFile = new List<string> { };
                ListFile.AddRange(Directory.EnumerateFiles(Dire));
                foreach (var CurrentFile in ListFile)
                {
                    string FileName = Path.GetFileName(CurrentFile);
                    //TotalList.Add(Path.GetDirectoryName(Item)); 
                    //Console.WriteLine(Spaces + FileName);
                    //File.AppendAllText(SavePath, Spaces + FileName + Environment.NewLine);
                    if(CurrentFile == ListFile.Last())
                    {
                        FileSpaces = Spaces + "└──";
                        File.AppendAllText(SavePath001, FileSpaces + FileName + Environment.NewLine);
                    }
                    else
                    {
                        FileSpaces = Spaces + "├──";
                        File.AppendAllText(SavePath001, FileSpaces + FileName + Environment.NewLine);
                    }
                }
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
    }
    
}
