using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 事件记录查询请求参数。
    /// </summary>
    public sealed class EventRecordQuery
    {
        /// <summary>
        /// 需要查询的事件类型数组，可选值为 sent、open、click、soft_bounce、hard_bounce、subscribe 和 unsubscribe。
        /// </summary>
        [JsonPropertyName("types")]
        public List<string> Types { get; set; } = new List<string>();

        /// <summary>
        /// 发送任务标识，使用发送接口或创建任务接口返回的 sendTaskId。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string SendTaskId { get; set; } = string.Empty;

        /// <summary>
        /// 页码，从 1 开始；不传时默认为 1。
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int? PageNo { get; set; }

        /// <summary>
        /// 每页返回数量；不传时默认为 10，可填写 1 至 1000。
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }
    }
}
