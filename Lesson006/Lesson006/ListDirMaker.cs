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
        void ListDirIter(string SomePath)
        {
            string [] Tempo = Directory.EnumerateDirectories(SomePath);
        }
    }
}
