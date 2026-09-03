using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 单封邮件发送请求。
    /// </summary>
    public sealed class WebpowerXSingleEmailRequest
    {
        /// <summary>
        /// 发件地址序列号。
        /// </summary>
        [JsonPropertyName("senderAddressSn")]
        public string SenderAddressSn { get; set; } = string.Empty;

        /// <summary>
        /// 发件人名称。
        /// </summary>
        [JsonPropertyName("senderName")]
        public string? SenderName { get; set; }

        /// <summary>
        /// 回复地址序列号。
        /// </summary>
        [JsonPropertyName("replyAddressSn")]
        public string? ReplyAddressSn { get; set; }

        /// <summary>
        /// 邮件主题。
        /// </summary>
        [JsonPropertyName("subject")]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// 收件人真正看到的主正文。
        /// </summary>
        [JsonPropertyName("content")]
        public WebpowerXContent Content { get; set; } = new WebpowerXContent();

        /// <summary>
        /// 列表摘要或预览内容。
        /// </summary>
        [JsonPropertyName("preheaderContent")]
        public WebpowerXContent? PreheaderContent { get; set; }

        /// <summary>
        /// 纯文本备用正文。
        /// </summary>
        [JsonPropertyName("plaintextMsgContent")]
        public WebpowerXContent? PlaintextMsgContent { get; set; }

        /// <summary>
        /// 单个收件人数据。
        /// </summary>
        [JsonPropertyName("recipient")]
        public WebpowerXRecipient Recipient { get; set; } = new WebpowerXRecipient();

        /// <summary>
        /// 附件列表。
        /// </summary>
        [JsonPropertyName("attachments")]
        public List<WebpowerXAttachment>? Attachments { get; set; }

        /// <summary>
        /// 用于保存接口扩展字段，避免未来字段变化时频繁改 SDK。
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object?>? AdditionalProperties { get; set; }
    }
}
