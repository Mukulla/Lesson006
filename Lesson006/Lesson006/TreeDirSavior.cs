using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson006
{
    class TreeDirSavior
    {
        public static void Show()
        {
            Console.WriteLine("Введите корневой каталог для вывода");
            string SomePath = Console.ReadLine();

            TraverseTree(SomePath);
        }
    }
}
