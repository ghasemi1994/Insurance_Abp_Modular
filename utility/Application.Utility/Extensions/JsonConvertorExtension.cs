

using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Application.Utility.Extensions;

public static class JsonConvertorExtension
{
    public static string ToJsonString(this object obj)
    {
        if (obj == null)
            return null;

        return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        });
    }
}
