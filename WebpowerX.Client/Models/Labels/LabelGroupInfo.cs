using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示标签分组信息。
    /// </summary>
    public sealed class LabelGroupInfo
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

        /// <summary>
        /// 创建时间。
        /// </summary>
        [JsonPropertyName("createDate")]
        public string? CreateDate { get; set; }

        /// <summary>
        /// 父分组序列号；根分组返回 null。
        /// </summary>
        [JsonPropertyName("parentSn")]
        public string? ParentSn { get; set; }
    }
}
