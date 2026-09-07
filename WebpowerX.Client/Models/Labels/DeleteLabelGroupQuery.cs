using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 删除标签分组查询参数。
    /// </summary>
    public sealed class DeleteLabelGroupQuery
    {
        /// <summary>
        /// 需要删除的标签分组序列号。
        /// </summary>
        [JsonPropertyName("groupSn")]
        public string GroupSn { get; set; } = string.Empty;
    }
}
