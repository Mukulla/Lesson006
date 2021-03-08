using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson006
{
    [Serializable]
    class ToDo
    {
        private string[] Title;
        private bool[] IsDone;
        private int Length{ get;}

        private string Zero = " ";

        public ToDo()
        {
            Title = new string[1];
            IsDone = new bool[1];
            Length = 1;
        }
        public ToDo( int Size )
        {
            if(Size < 1)
            {
                Size = 1;
            }
            Length = Size;
            Title = new string[Size];
            IsDone = new bool[Size];
        } 
        
        string GetTi(int Index)
        {
            if(Index >= 0 && Index < Length)
            {
                return Title[Index];
            }
            return Zero;
        }

        bool GetDo(int Index)
        {
            if (Index >= 0 && Index < Length)
            {
                return IsDone[Index];
            }
            return false;
        }
    }
}
