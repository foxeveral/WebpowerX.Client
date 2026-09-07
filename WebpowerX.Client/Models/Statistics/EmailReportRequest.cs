using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 邮件报告查询请求参数。
    /// </summary>
    public sealed class EmailReportRequest
    {
        /// <summary>
        /// 发送任务标识，使用发送接口或创建任务接口返回的 sendTaskId。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string SendTaskId { get; set; } = string.Empty;
    }
}
