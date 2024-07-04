using Newtonsoft.Json;

namespace ProductManagementWebApp.BLL
{
    public class Utility
    {

        public static T JsonResultDeserializer<T>(string input)
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                };
                T obj = JsonConvert.DeserializeObject<T>(input, settings);
                return obj;
            }
            catch (Exception ex)
            {
                return Activator.CreateInstance<T>();
            }
        }
    }
}
