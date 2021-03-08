using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson006
{
    class PackToDo
    {
        private ToDo[] WhatDo;
        private string Marker = "[X]";

        public void MakeTasks(int Size)
        {
            if(Size < 1)
            {
                Size = 1;
            }
            WhatDo = new ToDo[Size];
        }
        public void WriteTask(int Index, string Task001)
        {

        }
        public void Load(string SomePath)
        {
            if (!Directory.Exists(SomePath))
            {
                Console.WriteLine("Такого каталога нет");
                return;
            }
        }
    }
}
