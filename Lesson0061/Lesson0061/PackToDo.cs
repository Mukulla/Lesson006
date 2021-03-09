using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lesson0061
{
    class JsonPacker
    {
        static public void Load<T>(T SomeTasks001, string SomePath)
        {
            if (!File.Exists(SomePath))
            {
                Console.WriteLine("Такого файла не существует");
                return;
            }

            //string JsonFile = File.ReadAllText("house.json");
            string JsonFile = File.ReadAllText(SomePath);
            SomeTasks001 = JsonSerializer.Deserialize<T>(JsonFile);
        }

        static public void Save<T>(T SomeTasks001, string SomePath)
        {
            string json = JsonSerializer.Serialize(SomeTasks001);
            File.WriteAllText(SomePath, json);
        }
    }
}
