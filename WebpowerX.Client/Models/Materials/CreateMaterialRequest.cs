using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 创建邮件素材请求参数。
    /// </summary>
    public sealed class CreateMaterialRequest
    {
        /// <summary>
        /// 素材分组序列号；不传时创建到素材根目录。
        /// </summary>
        [JsonPropertyName("materialGroupSn")]
        public string? MaterialGroupSn { get; set; }

        /// <summary>
        /// 素材名称，用于素材列表、搜索和人工识别，最长 100 个字符。
        /// </summary>
        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; } = string.Empty;

        /// <summary>
        /// 素材内容类型，可选值为 plain 和 enjoyTemplate。
        /// </summary>
        [JsonPropertyName("materialType")]
        public string MaterialType { get; set; } = string.Empty;

        /// <summary>
        /// 素材的邮件正文，类型由 <see cref="MaterialType" /> 决定。
        /// </summary>
        [JsonPropertyName("materialContent")]
        public string MaterialContent { get; set; } = string.Empty;
    }
}
