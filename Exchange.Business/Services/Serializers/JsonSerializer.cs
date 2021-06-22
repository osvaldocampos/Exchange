using Exchange.Business.Interfaces;
using Newtonsoft.Json;

namespace Exchange.Business.Services.Serializers
{
    public class JsonSerializer: ISerializer
    {
        public JsonSerializer()
        {
        }

        public T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
