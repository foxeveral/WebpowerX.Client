using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台创建或更新素材后的返回结果。
    /// </summary>
    public sealed class MaterialUpsertResult
    {
        /// <summary>
        /// 素材序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材预览地址。
        /// </summary>
        [JsonPropertyName("previewUrl")]
        public string? PreviewUrl { get; set; }
    }
}
