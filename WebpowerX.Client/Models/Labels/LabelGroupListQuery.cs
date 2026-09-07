using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 标签分组列表查询参数。
    /// </summary>
    public sealed class LabelGroupListQuery
    {
        /// <summary>
        /// 排序字段，可选值为 createDate、updateDate 和 name；不传时按 updateDate 排序。
        /// </summary>
        [JsonPropertyName("sortField")]
        public string? SortField { get; set; }

        /// <summary>
        /// 排序方向，可选值为 asc 和 desc；不传时按 desc 排序。
        /// </summary>
        [JsonPropertyName("sortOrder")]
        public string? SortOrder { get; set; }
    }
}
