using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
/// <summary>
    /// 表示邮件素材详情。
    /// </summary>
    public sealed class MaterialDetails
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
        /// 素材的邮件正文。
        /// </summary>
        [JsonPropertyName("materialContent")]
        public string? MaterialContent { get; set; }

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

        /// <summary>
        /// 素材预览地址；没有可用预览地址时返回空字符串。
        /// </summary>
        [JsonPropertyName("previewUrl")]
        public string? PreviewUrl { get; set; }

        /// <summary>
        /// 素材测试主题；未设置时返回空字符串。
        /// </summary>
        [JsonPropertyName("testSubject")]
        public string? TestSubject { get; set; }
    }
}
