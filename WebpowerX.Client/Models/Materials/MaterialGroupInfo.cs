using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示素材分组信息。
    /// </summary>
    public sealed class MaterialGroupInfo
    {
        /// <summary>
        /// 素材分组序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材分组名称。
        /// </summary>
        [JsonPropertyName("groupName")]
        public string? GroupName { get; set; }

        /// <summary>
        /// 创建人名称。
        /// </summary>
        [JsonPropertyName("createName")]
        public string? CreateName { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [JsonPropertyName("createDate")]
        public string? CreateDate { get; set; }

        /// <summary>
        /// 最后更新人名称。
        /// </summary>
        [JsonPropertyName("updateName")]
        public string? UpdateName { get; set; }

        /// <summary>
        /// 最后更新时间。
        /// </summary>
        [JsonPropertyName("updateDate")]
        public string? UpdateDate { get; set; }

        /// <summary>
        /// 分组内的素材数量；接口以字符串返回。
        /// </summary>
        [JsonPropertyName("count")]
        public string? Count { get; set; }
    }
}
