using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using ProjectB_TaskManager.Classes.MyTasks;

namespace ProjectB_TaskManager.Classes.General
{
    public class DataReader
    {
        public static void ReadFromJsonFile<T>(string path, ref List<T> items)
        {
            try
            {
                string jsonFromFile = File.ReadAllText(path);

                JsonSerializerSettings settings = new JsonSerializerSettings { Converters = { new MyTaskConverter() } };
                items = JsonConvert.DeserializeObject<List<T>>(jsonFromFile, settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
    }

    public class MyTaskConverter : JsonConverter<MyTask>
    {
        public override MyTask ReadJson(JsonReader reader, Type objectType, MyTask existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            if (jObject["Title"] != null)
            {
                return jObject.ToObject<MyGeneralTask>();
            }
            else if (jObject["CourseName"] != null)
            {
                return jObject.ToObject<MyUniversityTask>();
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, MyTask value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
