using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using TRPO_labe_6.Models;

namespace TRPO_labe_6_WPF.Model
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
            using (var writer = new StreamWriter(Path))
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
