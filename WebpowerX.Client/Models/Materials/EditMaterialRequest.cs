using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 编辑邮件素材请求参数。
    /// </summary>
    public sealed class EditMaterialRequest
    {
        /// <summary>
        /// 邮件素材序列号。
        /// </summary>
        [JsonPropertyName("materialSn")]
        public string MaterialSn { get; set; } = string.Empty;

        /// <summary>
        /// 素材名称，用于素材列表、搜索和人工识别。
        /// </summary>
        [JsonPropertyName("materialName")]
        public string MaterialName { get; set; } = string.Empty;

        /// <summary>
        /// 素材的邮件正文；当前接口不允许改变素材类型。
        /// </summary>
        [JsonPropertyName("materialContent")]
        public string MaterialContent { get; set; } = string.Empty;

        /// <summary>
        /// 新的素材分组序列号；不传时保留素材原分组。
        /// </summary>
        [JsonPropertyName("materialGroupSn")]
        public string? MaterialGroupSn { get; set; }
    }
}
