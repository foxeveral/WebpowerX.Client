using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台创建或更新素材分组后的返回结果。
    /// </summary>
    public sealed class MaterialGroupUpsertResult
    {
        /// <summary>
        /// 素材分组序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材分组名称。
        /// </summary>
        [JsonPropertyName("materialGroupName")]
        public string? MaterialGroupName { get; set; }
    }
}
