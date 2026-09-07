using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 使用云文件和自定义内容创建发送任务的请求参数。
    /// </summary>
    public sealed class CreateCloudFileTaskRequest
    {
        /// <summary>
        /// 发送任务展示名称；便于管理后台识别，不参与邮件渲染，最长 500 个字符。
        /// </summary>
        [JsonPropertyName("sendTaskName")]
        public string? SendTaskName { get; set; }

        /// <summary>
        /// 客户可指定的任务标识；不传时由服务端生成，后续发送、报告和事件查询都使用该值。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string? SendTaskId { get; set; }

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
        /// 云文件任务完成后的结果通知地址；服务端以 PUT 发送任务状态、结果码、结果说明和数量。
        /// </summary>
        [JsonPropertyName("callbackUrl")]
        public string? CallbackUrl { get; set; }

        /// <summary>
        /// 任务固定使用的邮件主题；后续发送只替换普通 {$field} 占位符。
        /// </summary>
        [JsonPropertyName("subject")]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// 主邮件正文对象；本接口使用 html 或 plain，并通过普通 {$field} 占位符按收件人替换。
        /// </summary>
        [JsonPropertyName("content")]
        public EmailContent Content { get; set; } = new EmailContent();

        /// <summary>
        /// 邮件预览摘要对象；作为隐藏片段插入主 HTML 开头。
        /// </summary>
        [JsonPropertyName("preheaderContent")]
        public EmailContent? PreheaderContent { get; set; }

        /// <summary>
        /// 远程收件人文件对象；云文件任务必须提供。
        /// </summary>
        [JsonPropertyName("recipientFile")]
        public RecipientCloudFile RecipientFile { get; set; } = new RecipientCloudFile();
    }
}
