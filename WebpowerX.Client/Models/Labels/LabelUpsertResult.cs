using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台创建或更新标签后的返回结果。
    /// </summary>
    public sealed class LabelUpsertResult
    {
        /// <summary>
        /// 标签序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 标签名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 标签内部数值标识。
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }
    }
}
