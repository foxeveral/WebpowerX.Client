using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 单个收件人信息。
    /// </summary>
    public sealed class Recipient
    {
        /// <summary>
        /// 收件人邮箱。
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// 收件人姓名，通常可参与普通占位符替换。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 文档未固定描述的扩展字段，保留下来便于后续扩展。
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object?>? AdditionalProperties { get; set; }
    }
}
