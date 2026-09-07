using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 删除素材分组查询参数。
    /// </summary>
    public sealed class DeleteMaterialGroupQuery
    {
        /// <summary>
        /// 需要删除的素材分组序列号。
        /// </summary>
        [JsonPropertyName("materialGroupSn")]
        public string MaterialGroupSn { get; set; } = string.Empty;
    }
}
