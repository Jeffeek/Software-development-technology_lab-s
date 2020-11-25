using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace TRPO_labe_6.Models.FileWorkers
{
    public class JsonFileDeserializer<TType> : JsonFile<TType> 
            where TType : class
    {
        public JsonFileDeserializer(string path) : base(path) { }

        public TType Read()
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(TargetType);
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                TType @object = deserializer.ReadObject(fs) as TType;
                return @object;
            }
        }

        public async Task<TType> ReadAsync()
        {
            return await Task.Run(Read);
        }
    }
}
