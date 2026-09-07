using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 使用固定模板任务批量发送的请求参数。
    /// </summary>
    public sealed class SendWithinTemplateTaskToEmailsRequest
    {
        /// <summary>
        /// 已创建的发送任务标识；本次发送会归入该任务，后续报告和事件查询也使用它。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string SendTaskId { get; set; } = string.Empty;

        /// <summary>
        /// 收件人数组；每项必须包含 email，最少 1 个、最多 1000 个，元素中的动态字段按收件人分别参与个性化。
        /// </summary>
        [JsonPropertyName("recipients")]
        public List<Recipient> Recipients { get; set; } = new List<Recipient>();
    }
}
