using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json.Serialization;
using TRPO_labe_6.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TRPO_labe_6_console
{
    public class ShopsSerializer
    {
        public string Path { get; }

        public ShopsSerializer(string path)
        {
            Path = path;
        }

        public void RewriteAll(List<Shop> shops)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Shop>));
            using (var writer = new StreamWriter(Path, false))
            {
                writer.Write(String.Empty);
            }
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                serializer.WriteObject(fs, shops);
            }
        }
    }
}
