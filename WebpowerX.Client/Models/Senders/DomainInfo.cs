using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台发件域名信息。
    /// </summary>
    public sealed class DomainInfo
    {
        /// <summary>
        /// 发件域名序列号。
        /// </summary>
        [JsonPropertyName("domainSn")]
        public string? DomainSn { get; set; }

        /// <summary>
        /// 发件域名。
        /// </summary>
        [JsonPropertyName("domain")]
        public string? Domain { get; set; }

        /// <summary>
        /// 文档示例未固定描述的扩展字段。
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object?>? AdditionalProperties { get; set; }
    }
}
