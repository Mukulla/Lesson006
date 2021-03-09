using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace Lesson0061
{
    [Serializable]
    class ToDo
    {
        private List<string> Title = new List<string> { };
        private List<bool> IsDone = new List<bool> { };
        private int Length;

        private string Zero = " ";

        public ToDo()
        {
            Length = 0;
        }

        public void AddTask(string NewTask001)
        {
            Title.Add(NewTask001);
            IsDone.Add(false);
            ++Length;
        }

        public void MarkTask(int NumberTask001)
        {
            if(NumberTask001 >= 0 && NumberTask001 < Title.Count())
            {
                IsDone[NumberTask001] = true;
            }            
        }

        public void DeleteMarkedTasks()
        {
            for (int i = 0; i < Length; ++i)
            {
                if (IsDone[i])
                {
                    IsDone.RemoveAt(i);
                    Title.RemoveAt(i);
                }
            }
        }

        public void ShowTasks()
        {            
            int Number = 0;
            string Marker = "[X]";

            foreach (var CurrentTask in Title)
            {
                if(IsDone[Number])
                {
                    Marker = "[X]";
                    //Console.WriteLine("{ 0,3}: { 1,3}, { 2}", Number, Marker, CurrentTask);
                    Console.WriteLine($"{ Number, 3} { Marker,4} { CurrentTask, 19}");
                }
                else
                {
                    Marker = " ";
                    Console.WriteLine($"{ Number, 3} { Marker, 4} { CurrentTask, 19}");
                    //Console.WriteLine($"{Number} {Marker} {CurrentTask}");
                }
                ++Number;
            }
        }        
    }
}
