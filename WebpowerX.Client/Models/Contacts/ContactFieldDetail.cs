using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示联系人字段详情。
    /// </summary>
    public sealed class ContactFieldDetail
    {
        /// <summary>
        /// 联系人字段的英文标识。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }

        /// <summary>
        /// 联系人字段序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 联系人字段展示名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 是否允许作为查询条件。
        /// </summary>
        [JsonPropertyName("searchType")]
        public bool SearchType { get; set; }

        /// <summary>
        /// 是否允许作为排序字段。
        /// </summary>
        [JsonPropertyName("sortType")]
        public bool SortType { get; set; }
    }
}
