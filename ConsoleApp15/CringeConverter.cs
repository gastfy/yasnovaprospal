using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class CringeConverter
    {
        public static T CringeDeserializer<T>(string path)
        {
            string json = File.ReadAllText(path);
            T List = JsonConvert.DeserializeObject<T>(json);
            return List;
        }
        public static void CringeSerializer<T>(string path, T list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, json);
        }
    } // Кринж лист .адд нью кринж кринж обджект кринж плс килл ме
}
