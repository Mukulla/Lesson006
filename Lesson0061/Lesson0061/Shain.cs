using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson0061
{
    class Shain
    {
        //ФИО, должность, email, телефон, зарплата, возраст
        public string FIO { get; }       
        public string Position { get; }       
        public int Age { get; }

        public string Email { get; }
        public string Tel { get; }
        public int Salary { get; }

        public Shain()
        {
            FIO = "123";
            Position = "Uto";
            Age = 19;
            Email = "4";
            Tel = "567";
            Salary = 59;
        }
        public Shain(string FIO001, string Position001, int Age001, string Email001, string Tel001, int Salary001)
        {
            FIO = FIO001;
            Position = Position001;
            if (Age001 < 1)
            {
                Age001 = 0;
            }
            Age = Age001;

            Email = Email001;
            Tel = Tel001;

            if (Salary001 < 1)
            {
                Salary001 = 0;
            }
            Salary = Salary001;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Полное имя сотрудника: {FIO} Должность:{Position} Возраст: {Age}");
            Console.WriteLine($"Email: {Email} Телефон: {Tel} Заработная плата: {Salary}");
        }
    }
}
