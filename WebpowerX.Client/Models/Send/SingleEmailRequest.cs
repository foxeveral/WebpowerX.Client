using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 单封邮件发送请求，适用于发送单封事务邮件和发送单封普通邮件。
    /// </summary>
    public sealed class SingleEmailRequest
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
        /// 主邮件正文对象；type 为 enjoyTemplate 时对 value 执行 Enjoy 渲染。
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
        /// 单个收件人对象；email 必填，其余动态字段可用于普通 {$field} 占位符。
        /// </summary>
        [JsonPropertyName("recipient")]
        public Recipient Recipient { get; set; } = new Recipient();

        /// <summary>
        /// Enjoy 模板的业务数据对象；模板通过 substitutionObj.data.* 读取字段。
        /// </summary>
        [JsonPropertyName("substitutionObj")]
        public Substitution? SubstitutionObj { get; set; }
    }
}
