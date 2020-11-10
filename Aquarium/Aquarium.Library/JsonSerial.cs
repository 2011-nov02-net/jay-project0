using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Aquarium.Library
{
    public class JsonSerial
    {
        public JsonSerial(string filePath)
        {
            _filePath = filePath;
        }
        private string _filePath;
        public void ReadJson()
        {
            using (StreamReader writer = new StreamReader(_filePath))
            {
                string json = writer.ReadToEnd();
                List<object> items = JsonConvert.DeserializeObject<List<object>>(json);
            }
        }
        public void WriteJson(object data)
        {
            string json = JsonConvert.SerializeObject(data);
            using var writer = new StreamWriter(_filePath);
            {
                writer.Write(json);
            }
        }
    }

}