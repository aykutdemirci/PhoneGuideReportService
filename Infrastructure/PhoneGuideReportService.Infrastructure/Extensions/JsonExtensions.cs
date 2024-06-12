using Newtonsoft.Json;

namespace PhoneGuideReportService.Infrastructure.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(this string input)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));

            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
