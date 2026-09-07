using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台创建发送任务后的返回结果。
    /// </summary>
    public sealed class SendTaskCreateResult
    {
        /// <summary>
        /// 发送任务标识。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string? SendTaskId { get; set; }

        /// <summary>
        /// 发送任务名称。
        /// </summary>
        [JsonPropertyName("sendTaskName")]
        public string? SendTaskName { get; set; }
    }
}
