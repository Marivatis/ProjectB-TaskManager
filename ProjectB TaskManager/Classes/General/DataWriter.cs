using Newtonsoft.Json;
using ProjectB_TaskManager.Classes.MyTasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace ProjectB_TaskManager.Classes.General
{
    public class DataWriter
    {
        public static void WriteToJsonFile(List<MyTask> items, string path)
        {
            //try
            //{
            //    if (items.Count == 0)
            //        return false;

            //    string jsonString = string.Empty;

            //    DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(MyTask));

            //    using (FileStream file = new FileStream(path, FileMode.Create))
            //    {
            //        json.WriteObject(file, items);
            //        file.Close();
            //    }

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    return false;
            //}

            
            string json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, json);

            //// Десериализация из JSON
            //string jsonFromFile = File.ReadAllText("taskManager.json");
            //MyTaskManager deserializedTaskManager = JsonConvert.DeserializeObject<MyTaskManager>(jsonFromFile);

            //// Вывод информации
            //foreach (var task in deserializedTaskManager)
            //{
            //    if (task is MyGeneralTask generalTask)
            //    {
            //        Console.WriteLine($"MyGeneralTask with GeneralProperty: {generalTask.GeneralProperty}");
            //    }
            //    else if (task is MyUniversityTask universityTask)
            //    {
            //        Console.WriteLine($"MyUniversityTask with UniversityProperty: {universityTask.UniversityProperty}");
            //    }
            //}

        }
    }
}
