using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 标签下联系人分页查询参数。
    /// </summary>
    public sealed class ContactByLabelPageQuery
    {
        /// <summary>
        /// 页码，取值范围 1-100。
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int? PageNo { get; set; }

        /// <summary>
        /// 每页返回数量，从 1 开始。
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }

        /// <summary>
        /// 标签序列号，用于指定需要查询的标签。
        /// </summary>
        [JsonPropertyName("sn")]
        public string Sn { get; set; } = string.Empty;
    }
}
