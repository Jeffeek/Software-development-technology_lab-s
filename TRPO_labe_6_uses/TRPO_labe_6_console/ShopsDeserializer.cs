using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    public class ShopsDeserializer
    {
        public string Path { get; }

        public ShopsDeserializer(string path)
        {
            Path = path;
        }

        public List<Shop> GetAll()
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(List<Shop>));
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                List<Shop> shops = deserializer.ReadObject(fs) as List<Shop>;
                return shops;
            }
        }
    }
}
