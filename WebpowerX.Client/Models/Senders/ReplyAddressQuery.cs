using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 获取回复地址接口的查询参数。
    /// </summary>
    public sealed class ReplyAddressQuery
    {
        /// <summary>
        /// 页码，从 1 开始。
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int? PageNo { get; set; }

        /// <summary>
        /// 每页返回数量，从 1 开始。
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }

        /// <summary>
        /// 搜索关键字，仅用于按回复邮箱模糊匹配。
        /// </summary>
        [JsonPropertyName("keyword")]
        public string? Keyword { get; set; }
    }
}
