using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台邮件通道信息。
    /// </summary>
    public sealed class EmailRouteInfo
    {
        /// <summary>
        /// 邮件通道序列号。
        /// </summary>
        [JsonPropertyName("emailRouteSn")]
        public string? EmailRouteSn { get; set; }

        /// <summary>
        /// 邮件通道名称。
        /// </summary>
        [JsonPropertyName("emailRouteName")]
        public string? EmailRouteName { get; set; }

        /// <summary>
        /// 文档示例未固定描述的扩展字段。
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object?>? AdditionalProperties { get; set; }
    }
}
