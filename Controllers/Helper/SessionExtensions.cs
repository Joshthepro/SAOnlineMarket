using Microsoft.AspNetCore.Http; 
using Newtonsoft.Json; // Used for JSON serialization and deserialization

namespace SAOnlineMart.Helpers 
{
    public static class SessionExtensions // Static class to extend ISession with additional methods
    {
        // Extension method to set an object as a JSON string in the session
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // Serialize the object to a JSON string and store it in session using the provided key
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Extension method to retrieve an object from the session by deserializing a JSON string
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            // Retrieve the JSON string from the session using the provided key
            var value = session.GetString(key);

            // If the value is null, return the default value of the type 
            // Otherwise, deserialize the JSON string back into an object of type T
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
