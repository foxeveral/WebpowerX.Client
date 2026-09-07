using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 创建发件地址接口的请求参数。
    /// </summary>
    public sealed class CreateSenderRequest
    {
        /// <summary>
        /// 发件地址 local 部分，不包含 @ 和域名。
        /// </summary>
        [JsonPropertyName("localPart")]
        public string LocalPart { get; set; } = string.Empty;

        /// <summary>
        /// 发件域名序列号。
        /// </summary>
        [JsonPropertyName("domainSn")]
        public string DomainSn { get; set; } = string.Empty;

        /// <summary>
        /// 邮件通道序列号。
        /// </summary>
        [JsonPropertyName("emailRouteSn")]
        public string EmailRouteSn { get; set; } = string.Empty;
    }
}
