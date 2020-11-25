using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace TRPO_labe_6.Models.FileWorkers
{
    public class JsonFileSerializer<TType> : JsonFile<TType> 
            where TType : class
    {
        private bool _alreadyEmpty = false;

        public JsonFileSerializer(string path) : base(path) { }

        public void Rewrite(TType @object)
        {
            if (!_alreadyEmpty)
                WriteEmptySpace();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(TargetType);
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
                serializer.WriteObject(fs, @object);
            _alreadyEmpty = false;
        }

        public async Task RewriteAsync(TType @object)
        {
            await WriteEmptySpaceAsync();
            await Task.Run(() => Rewrite(@object));
            _alreadyEmpty = true;
        }

        private void WriteEmptySpace()
        {
            using (var writer = new StreamWriter(Path, false))
                writer.Write(String.Empty);
        }

        private async Task WriteEmptySpaceAsync()
        {
            using (var writer = new StreamWriter(Path, false))
                await writer.WriteAsync(String.Empty);
        }
    }
}
