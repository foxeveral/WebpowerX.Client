using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 批量发送普通邮件请求；单次最多 1000 个收件人，不支持 Enjoy 业务数据。
    /// </summary>
    public sealed class BulkEmailRequest
    {
        /// <summary>
        /// 发件地址序列号，用于指定已配置且可用的发件地址。
        /// </summary>
        [JsonPropertyName("senderAddressSn")]
        public string SenderAddressSn { get; set; } = string.Empty;

        /// <summary>
        /// 收件人看到的发件人名称；支持普通 {$field} 占位符，不执行 Enjoy。
        /// </summary>
        [JsonPropertyName("senderName")]
        public string? SenderName { get; set; }

        /// <summary>
        /// 回复地址序列号；不传则不设置 Reply-To，传入时必须是当前企业的有效回复地址。
        /// </summary>
        [JsonPropertyName("replyAddressSn")]
        public string? ReplyAddressSn { get; set; }

        /// <summary>
        /// 本次邮件主题；不能为空，支持普通 {$field} 占位符。
        /// </summary>
        [JsonPropertyName("subject")]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// 主邮件正文对象；通过普通 {$field} 占位符读取收件人或 CSV 同名字段。
        /// </summary>
        [JsonPropertyName("content")]
        public EmailContent Content { get; set; } = new EmailContent();

        /// <summary>
        /// 邮件预览摘要对象；作为隐藏片段插入主 HTML 开头。
        /// </summary>
        [JsonPropertyName("preheaderContent")]
        public EmailContent? PreheaderContent { get; set; }

        /// <summary>
        /// 纯文本备用正文对象，供不能显示 HTML 的客户端使用。
        /// </summary>
        [JsonPropertyName("plaintextMsgContent")]
        public EmailContent? PlaintextMsgContent { get; set; }

        /// <summary>
        /// 附件数组；可整体不传，传入时最多 5 个附件。
        /// </summary>
        [JsonPropertyName("attachments")]
        public List<EmailAttachment>? Attachments { get; set; }

        /// <summary>
        /// 收件人数组；每项必须包含 email，最少 1 个、最多 1000 个，元素中的动态字段按收件人分别参与个性化。
        /// </summary>
        [JsonPropertyName("recipients")]
        public List<Recipient> Recipients { get; set; } = new List<Recipient>();
    }
}
