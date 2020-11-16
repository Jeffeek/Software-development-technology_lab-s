using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_console
{
    class ShopsSerializer
    {
        public string Path { get; }

        public ShopsSerializer(string path)
        {
            Path = path;
        }

        public void RewriteAll(List<Shop> shops)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Shop>));
            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                serializer.Serialize(fs, shops);
            }
        }
    }
}
