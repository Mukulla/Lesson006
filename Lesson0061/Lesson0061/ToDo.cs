using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Lesson0061
{
    struct Str_Task
    {
        public string Title;
        public bool IsDone;        
    }
    [Serializable]
    class ToDo
    {
        private Str_Task[] Tasks001;
        private int Length{ get;}

        private Str_Task Zero = SetStr(" ", false);

        public ToDo()
        {
            Tasks001 = new Str_Task[1];
            Length = 1;
        }
        public ToDo( int Size )
        {
            if(Size < 1)
            {
                Size = 1;
            }
            Length = Size;
            Tasks001 = new Str_Task[Size];
        }

        public Str_Task this[int Index]
        {
            set 
            {
                if (MyFunc.IsInBorders(ref Index, Length))
                {
                    Tasks001[Index] = value;
                }
            }
            get
            {
                if (MyFunc.IsInBorders(ref Index, Length))
                {
                    return Tasks001[Index];
                }
                return Zero;
            }
        }
        
        static public Str_Task SetStr( string SomeTitle, bool SomeDone)
        {
            Str_Task Tempo = new Str_Task();
            Tempo.Title = SomeTitle;
            Tempo.IsDone = SomeDone;
            return Tempo;
        }
    }
}
