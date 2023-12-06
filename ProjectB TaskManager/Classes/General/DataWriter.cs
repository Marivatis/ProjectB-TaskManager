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
    public class DataWriter<T>
    {
        private readonly List<T> items;

        public DataWriter(List<T> items) 
        {
            this.items = items;
        }

        public bool WriteToJsonFile(string path)
        {
            try
            {
                if (items.Count == 0)
                    return false;

                string json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(path, json);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
