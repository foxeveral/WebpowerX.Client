using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示邮件素材列表项。
    /// </summary>
    public sealed class MaterialInfo
    {
        /// <summary>
        /// 邮件素材序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材名称。
        /// </summary>
        [JsonPropertyName("materialName")]
        public string? MaterialName { get; set; }

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
        /// 素材正文类型：plain 表示普通内容，enjoyTemplate 表示 Enjoy 模板。
        /// </summary>
        [JsonPropertyName("materialType")]
        public string? MaterialType { get; set; }
    }
}
