using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 获取发件域名可用邮件通道接口的查询参数。
    /// </summary>
    public sealed class EmailRouteOverDomainQuery
    {
        /// <summary>
        /// 发件域名序列号，必填。
        /// </summary>
        [JsonPropertyName("domainSn")]
        public string DomainSn { get; set; } = string.Empty;
    }
}
