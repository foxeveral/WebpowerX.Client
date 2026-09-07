using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 使用固定模板任务发送单封邮件的请求参数。
    /// </summary>
    public sealed class SendWithinTemplateTaskRequest
    {
        /// <summary>
        /// 已创建的发送任务标识；本次发送会归入该任务，后续报告和事件查询也使用它。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string SendTaskId { get; set; } = string.Empty;

        /// <summary>
        /// 单个收件人对象；email 必填，其余动态字段可用于普通 {$field} 占位符。
        /// </summary>
        [JsonPropertyName("recipient")]
        public Recipient Recipient { get; set; } = new Recipient();

        /// <summary>
        /// Enjoy 模板的业务数据对象；模板通过 substitutionObj.data.* 读取字段，字段名必须与创建任务时的模板一致。
        /// </summary>
        [JsonPropertyName("substitutionObj")]
        public Substitution? SubstitutionObj { get; set; }
    }
}
