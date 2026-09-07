using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 创建标签请求参数。
    /// </summary>
    public sealed class CreateLabelRequest
    {
        /// <summary>
        /// 标签分组序列号；传空时使用默认分组。
        /// </summary>
        [JsonPropertyName("groupSn")]
        public string GroupSn { get; set; } = string.Empty;

        /// <summary>
        /// 标签名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
