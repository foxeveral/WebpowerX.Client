using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台创建或更新标签分组后的返回结果。
    /// </summary>
    public sealed class LabelGroupUpsertResult
    {
        /// <summary>
        /// 标签分组序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 标签分组名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
