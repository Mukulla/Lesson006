using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson0061
{
    class Program
    {
        static void Main(string[] args)
        {
            int CountPars = 2;
            string[] Denuntiatio = new string[]
            {
                "Запись содержимого папки по указанному пути в файл",
                "Список задач",
                "Запись набора числе в бинарный файл"
            };
            //Console.WriteLine(System.Text.Encoding.Default.HeaderName);
            //Цикл-обработчик каждого задания
            for (int i = 1; i < CountPars; ++i)
            {
                //Вывод части и названия задания
                Console.WriteLine($"Часть {i + 1}: {Denuntiatio[i]}");

                switch (i)
                {
                    case 0:
                        ListDirMaker.LaunchDirWriters();
                        break;
                    case 1:
                        Tasker();
                        break;
                }
                if (i == 2)
                {


                    Console.WriteLine();
                    Console.WriteLine("Все части пройдены");
                    Console.WriteLine("Для выхода нажмите любую клавишу");
                    Console.ReadKey();

                    break;
                }

                Console.WriteLine();
                Console.WriteLine("Для перехода к следующей части нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();

            }
        }

        static void Tasker()
        {
            ToDo NewTask001 = new ToDo();
            NewTask001.AddTask("Wake Up Alive");
            NewTask001.AddTask("Eat");
            NewTask001.AddTask("Do some Stuff");
            NewTask001.AddTask("Belive in MySelf");

            NewTask001.MarkTask(3);

            Console.WriteLine("Содержимое созданных задач" + Environment.NewLine);
            NewTask001.ShowTasks();


            NewTask001.DeleteMarkedTasks();
            JsonPacker.Save<ToDo>(NewTask001, "Tasks.json");

            Console.WriteLine("Содержимое сохранённого файла" + Environment.NewLine);
            JsonPacker.Load<ToDo>(NewTask001, "Tasks.json");

            NewTask001.ShowTasks();
        }
        /*
        static void ShowDir()
        {
            Console.WriteLine("Введите путь папки");
            string SomeDir = Console.ReadLine();
            
            //Console.WriteLine("Введите для сохранения списка всего содержимого в папке по пути");
            //string SaveDir = Console.ReadLine();
            string[] SaveDir = {@"DirsIter.txt", @"DirsRec.txt" };

            //ShowDirIter(SomeDir, SaveDir[0]);
            ShowDirRec(SomeDir, SaveDir[1], " ");
        }
        static void ShowDirIter(string SomePath, string SavePath)
        {
            List<string> ListDire = new List<string> { SomePath };
            List<string> TotalList = new List<string> {};

            while (ListDire.Count > 0)
            {
                string CurrentDir = ListDire[ListDire.Count - 1];

                List<string> ListFile = new List<string> { };
                ListFile.AddRange(Directory.EnumerateFiles(CurrentDir));
                foreach (var Item in ListFile)
                {
                    
                    //TotalList.Add(Path.GetDirectoryName(Item)); 
                    //Console.WriteLine(Path.GetFileName(Item));
                }
                
                ListDire.RemoveAt(ListDire.Count - 1);
                
                //Console.WriteLine(Path.GetDirectoryName(CurrentDir));
                //File.AppendAllText(SaveDir, CurrentDir + Environment.NewLine);
                ListDire.AddRange(Directory.EnumerateDirectories(CurrentDir));
                
                CurrentDir = Path.GetDirectoryName(CurrentDir);
                Console.WriteLine(CurrentDir);

                TotalList.Add(CurrentDir);                
            }
            /*
            TotalList.Reverse();

            foreach (var Item in TotalList)
            {
                File.AppendAllText(SavePath, Item + Environment.NewLine);
            }*//*
        }
        static void ShowDirRec(string SomePath, string SavePath, string Shifter)
        {
            Shifter = Shifter + "  ";
            string[] SomeDir = Directory.GetDirectories(SomePath);
            string[] SomeFile = Directory.GetFiles(SomePath);

            for (int i = 0; i < SomeDir.Length; ++i)
            {
                DirectoryInfo DName = new DirectoryInfo(SomeDir[i]);
                
                //Console.WriteLine(Shifter + DName.Name);
                if (SomeDir[i] == SomeDir[SomeDir.Length - 1])
                {
                    //Shifter += "└──";
                    Console.WriteLine(Shifter + DName.Name);
                    ShowDirRec(SomeDir[i], SavePath, Shifter);
                }
                else
                {
                    //Shifter += "  ";
                    Console.WriteLine(Shifter + DName.Name);
                    ShowDirRec(SomeDir[i], SavePath, Shifter);
                }
                
            }
            /*
            foreach (var Dir in SomeDir)
            {
                DirectoryInfo DName = new DirectoryInfo(Dir);
                Console.WriteLine(Shifter + DName.Name);

                ShowDirRec(Dir, SavePath, Shifter);
                //ShowDirRec(Path.GetDirectoryName(Dir), SavePath);
                //Console.WriteLine(Path.GetDirectoryName(Dir));
                //File.AppendAllText(SavePath, Dir + Environment.NewLine);                
            }
            
            //string[] SomeFile = Directory.GetFiles(SomePath);
            string FileShifter = '|' + Shifter;

            for (int i = 0; i < SomeFile.Length; ++i)
            {
                //Console.WriteLine(Shifter + Path.GetFileName(SomeFile[i]));
                if(SomeFile[i] == SomeFile[SomeFile.Length - 1])
                {
                    FileShifter = Shifter + "└──";
                    Console.WriteLine(FileShifter + Path.GetFileName(SomeFile[i]));
                }
                else
                {
                    FileShifter = Shifter + "├──";
                    Console.WriteLine(FileShifter + Path.GetFileName(SomeFile[i]));
                }
                //Console.WriteLine(File);
                //File.AppendAllText(SavePath, File + Environment.NewLine);
            }

            //C:\Git\Lessons\Lesson001
        }*/
    }
}
