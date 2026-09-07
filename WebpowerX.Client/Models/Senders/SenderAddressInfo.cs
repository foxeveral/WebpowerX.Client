using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台发件地址信息。
    /// </summary>
    public sealed class SenderAddressInfo
    {
        /// <summary>
        /// 发件地址序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 发件地址序列号，兼容文档示例中的字段名。
        /// </summary>
        [JsonPropertyName("senderAddressSn")]
        public string? SenderAddressSn { get; set; }

        /// <summary>
        /// 发件邮箱。
        /// </summary>
        [JsonPropertyName("fromEmail")]
        public string? FromEmail { get; set; }

        /// <summary>
        /// 发件域名序列号。
        /// </summary>
        [JsonPropertyName("domainSn")]
        public string? DomainSn { get; set; }

        /// <summary>
        /// 邮件通道序列号。
        /// </summary>
        [JsonPropertyName("emailRouteSn")]
        public string? EmailRouteSn { get; set; }
    }
}
