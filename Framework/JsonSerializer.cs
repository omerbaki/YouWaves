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
        Task<object> Import(string fileName);

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

        public async Task<object> Import(string fileName)
        {
            string serializedObj;
            using (StreamReader reader = File.OpenText(fileName))
            {
                serializedObj = await reader.ReadToEndAsync();
            }
            
            return JsonConvert.DeserializeObject(serializedObj);
        }
    }
}
