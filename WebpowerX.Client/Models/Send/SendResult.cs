using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 发送类接口受理后的核心返回信息。
    /// </summary>
    public sealed class SendResult
    {
        /// <summary>
        /// 发送请求标识；联系技术支持排查时请提供该标识。
        /// </summary>
        [JsonPropertyName("responseId")]
        public string? ResponseId { get; set; }

        /// <summary>
        /// 发送任务标识；用于邮件报告和事件记录查询。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string? SendTaskId { get; set; }
    }
}
