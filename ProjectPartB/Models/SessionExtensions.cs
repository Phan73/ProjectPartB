using Newtonsoft.Json;
using System.Text.Json;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.Set(key, System.Text.Json.JsonSerializer.Serialize(value));
    }
    public static  T Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null? default(T): System.Text.Json.JsonSerializer.Deserialize<T>(value);
    }
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }


    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonConvert.DeserializeObject<T>(value);
    }
}
