using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    class ShopsDeserializer
    {
        public string Path { get; }

        public ShopsDeserializer(string path)
        {
            Path = path;
        }

        public List<Shop> GetAll()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Shop>));
            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                List<Shop> shops = deserializer.Deserialize(fs) as List<Shop>;
                return shops;
            }
        }
    }
}
