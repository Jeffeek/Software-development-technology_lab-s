using System;

namespace TRPO_labe_6.Models.FileWorkers
{
    public abstract class JsonFile<TType> where TType : class
    {
        public string Path { get; }
        public Type TargetType { get; }

        protected JsonFile(string path)
        {
            Path = path;
            TargetType = typeof(TType);
        }
    }
}
