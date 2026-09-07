using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 在个性化任务中发送邮件的请求参数。
    /// </summary>
    public sealed class SendWithinPersonalizedTaskRequest
    {
        /// <summary>
        /// 已创建的发送任务标识；本次发送会归入该任务，后续报告和事件查询也使用它。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string SendTaskId { get; set; } = string.Empty;

        /// <summary>
        /// 本次邮件显示的发件人名称，会覆盖创建个性化任务时保存的名称；支持普通 {$field}，不执行 Enjoy。
        /// </summary>
        [JsonPropertyName("senderName")]
        public string? SenderName { get; set; }

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
