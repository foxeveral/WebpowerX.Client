using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 素材分组列表查询参数。
    /// </summary>
    public sealed class MaterialGroupListQuery
    {
        /// <summary>
        /// 搜索关键字，用于按素材分组名称搜索。
        /// </summary>
        [JsonPropertyName("keywords")]
        public string? Keywords { get; set; }

        /// <summary>
        /// 排序字段，可选值为 groupName、createDate 和 updateDate；不传时按 updateDate 排序。
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
