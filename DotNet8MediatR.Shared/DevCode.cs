namespace DotNet8MediatR.Shared;

public static class DevCode
{
    public static T ToEnum<T>(this string value) where T : Enum
    {
        try
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        catch
        {
            return (T)Enum.ToObject(typeof(T), 0);
        }
    }
    
    public static T? ToObject<T>(this string? jsonStr)
    {
        try
        {
            if (jsonStr != null)
            {
                var test = JsonConvert.DeserializeObject<T>(jsonStr,
                    new JsonSerializerSettings { DateParseHandling = DateParseHandling.DateTimeOffset });
                return test;
            }
        }
        catch
        {
            return (T)Convert.ChangeType(jsonStr, typeof(T))!;
        }

        return default;
    }
}