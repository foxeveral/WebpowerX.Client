using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 邮件素材分页查询参数。
    /// </summary>
    public sealed class EmailMaterialPageQuery
    {
        /// <summary>
        /// 页码，取值范围 1-1000。
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int? PageNo { get; set; }

        /// <summary>
        /// 每页返回数量，取值范围 1-1000。
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }

        /// <summary>
        /// 素材分组序列号；传入时只查询该分组下的素材。
        /// </summary>
        [JsonPropertyName("groupSn")]
        public string? GroupSn { get; set; }

        /// <summary>
        /// 搜索关键字，用于按素材名称、创建者或更新者搜索。
        /// </summary>
        [JsonPropertyName("keywords")]
        public string? Keywords { get; set; }

        /// <summary>
        /// 排序字段，可选值为 materialName、createDate 和 updateDate；不传时按 updateDate 排序。
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
