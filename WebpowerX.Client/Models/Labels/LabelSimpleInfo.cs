using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示标签基础信息。
    /// </summary>
    public sealed class LabelSimpleInfo
    {
        /// <summary>
        /// 标签或业务对象名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 标签或业务对象序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }
    }
}
