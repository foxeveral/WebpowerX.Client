using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 获取发件地址接口的查询参数。
    /// </summary>
    public sealed class SenderQuery
    {
        /// <summary>
        /// 发件地址序列号，精确匹配。
        /// </summary>
        [JsonPropertyName("senderAddressSn")]
        public string? SenderAddressSn { get; set; }

        /// <summary>
        /// 发件邮箱，支持模糊查询。
        /// </summary>
        [JsonPropertyName("fromEmail")]
        public string? FromEmail { get; set; }

        /// <summary>
        /// 发件域名序列号，精确匹配。
        /// </summary>
        [JsonPropertyName("domainSn")]
        public string? DomainSn { get; set; }

        /// <summary>
        /// 邮件通道序列号，精确匹配。
        /// </summary>
        [JsonPropertyName("emailRouteSn")]
        public string? EmailRouteSn { get; set; }
    }
}
