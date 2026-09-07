using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 创建个性化发送任务的请求参数。
    /// </summary>
    public sealed class CreatePersonalizedTaskRequest
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
    }
}
