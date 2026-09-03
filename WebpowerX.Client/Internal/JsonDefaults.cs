using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Internal
{
    /// <summary>
    /// 统一的 JSON 序列化配置。
    /// </summary>
    internal static class JsonDefaults
    {
        /// <summary>
        /// 统一复用的序列化选项，保证请求和响应格式一致。
        /// </summary>
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true
        };
    }
}
