using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示联系人分页列表项。
    /// </summary>
    public sealed class ContactInfo
    {
        /// <summary>
        /// 联系人唯一标识。
        /// </summary>
        [JsonPropertyName("customerId")]
        public string? CustomerId { get; set; }

        /// <summary>
        /// 联系人邮箱。
        /// </summary>
        [JsonPropertyName("邮箱")]
        public string? Email { get; set; }

        /// <summary>
        /// 联系人名称。
        /// </summary>
        [JsonPropertyName("联系人名称")]
        public string? Name { get; set; }

        /// <summary>
        /// 联系人手机号。
        /// </summary>
        [JsonPropertyName("手机号")]
        public string? Mobile { get; set; }

        /// <summary>
        /// 联系人微信字段值。
        /// </summary>
        [JsonPropertyName("微信")]
        public string? WeChat { get; set; }

        /// <summary>
        /// 联系人导入时间。
        /// </summary>
        [JsonPropertyName("导入时间")]
        public string? ImportTime { get; set; }

        /// <summary>
        /// 联系人最后更新时间。
        /// </summary>
        [JsonPropertyName("更新时间")]
        public string? UpdateTime { get; set; }

        /// <summary>
        /// 企业自定义联系人字段。
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object?>? AdditionalProperties { get; set; }
    }
}
