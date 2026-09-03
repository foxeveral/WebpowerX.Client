using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 发送类接口受理后的核心返回信息。
    /// </summary>
    public sealed class WebpowerXSendTaskResponse
    {
        /// <summary>
        /// 发送请求标识。
        /// </summary>
        [JsonPropertyName("responseId")]
        public string? ResponseId { get; set; }

        /// <summary>
        /// 发送任务标识，后续查报告时会用到。
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
