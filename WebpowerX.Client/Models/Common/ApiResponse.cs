using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// WebpowerX 接口的统一响应包装。
    /// </summary>
    /// <typeparam name="T">业务数据类型。</typeparam>
    public sealed class ApiResponse<T>
    {
        /// <summary>
        /// 业务码。0 表示成功受理。
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// 返回消息，用于提示成功或失败原因。
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// 调用方请求标识。
        /// </summary>
        [JsonPropertyName("requestId")]
        public string? RequestId { get; set; }

        /// <summary>
        /// 本次接口响应标识。
        /// </summary>
        [JsonPropertyName("responseId")]
        public string? ResponseId { get; set; }

        /// <summary>
        /// 链路追踪号，排查问题时很有用。
        /// </summary>
        [JsonPropertyName("traceNumber")]
        public string? TraceNumber { get; set; }

        /// <summary>
        /// 业务数据本体。
        /// </summary>
        [JsonPropertyName("data")]
        public T Data { get; set; } = default!;

        /// <summary>
        /// 快速判断接口是否被成功受理。
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess => Code == 0;
    }
}
