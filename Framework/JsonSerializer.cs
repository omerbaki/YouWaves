using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Framework
{
    public interface IJsonSerializer
    {
        Task Export(string fileName, object aObj);
    }

    public class JsonSerializer : IJsonSerializer
    {
        public async Task Export(string fileName, object aObj)
        {
            string serializedObj = JsonConvert.SerializeObject(aObj);
            using (StreamWriter writer = File.CreateText(fileName))
            {
                await writer.WriteAsync(serializedObj);
            }
        }

        public object Import(string fileName)
        {
            string value = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject(value);
        }
    }
}
