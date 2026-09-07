using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 联系人字段分页查询参数。
    /// </summary>
    public sealed class ContactFieldPageQuery
    {
        /// <summary>
        /// 字段英文名，用于接口识别联系人属性。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }

        /// <summary>
        /// 排序字段，可选值为 createTime 和 updateTime；不传时按 updateTime 排序。
        /// </summary>
        [JsonPropertyName("sortField")]
        public string? SortField { get; set; }

        /// <summary>
        /// 排序方向，可选值为 asc 和 desc；不传时按 desc 排序。
        /// </summary>
        [JsonPropertyName("sortOrder")]
        public string? SortOrder { get; set; }

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
    }
}
