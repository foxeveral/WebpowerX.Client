using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 联系人分页列表查询参数。
    /// </summary>
    public sealed class ContactPageListQuery
    {
        /// <summary>
        /// 要检索的联系人字段序列号，使用联系人字段详情接口返回且允许搜索的字段 sn。
        /// </summary>
        [JsonPropertyName("searchField")]
        public string? SearchField { get; set; }

        /// <summary>
        /// 与 <see cref="SearchField" /> 配套的检索值；未指定检索字段时不要单独传入。
        /// </summary>
        [JsonPropertyName("searchValue")]
        public string? SearchValue { get; set; }

        /// <summary>
        /// 页码，取值范围 1-100。
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int? PageNo { get; set; }

        /// <summary>
        /// 每页返回数量，取值范围 1-1000。
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }

        /// <summary>
        /// 排序字段，使用联系人字段详情接口返回且允许排序的 fieldName；不传时按 updateDate 排序。
        /// </summary>
        [JsonPropertyName("sortField")]
        public string? SortField { get; set; }

        /// <summary>
        /// 排序方向，可选值为 asc 和 desc；不传时按 desc 排序。
        /// </summary>
        [JsonPropertyName("sortOrder")]
        public string? SortOrder { get; set; }

        /// <summary>
        /// 联系人范围：1 实名客户、2 匿名客户、3 微信粉丝、4 全部客户。
        /// </summary>
        [JsonPropertyName("customerType")]
        public int? CustomerType { get; set; }

        /// <summary>
        /// 公众号 ID 列表；仅 CustomerType 为 3 时用于限定联系人所属公众号范围。
        /// </summary>
        [JsonPropertyName("appIds")]
        public List<string>? AppIds { get; set; }
    }
}
