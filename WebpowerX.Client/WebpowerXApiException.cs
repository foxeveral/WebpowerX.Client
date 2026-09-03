using System;

namespace WebpowerX.Client
{
    /// <summary>
    /// WebpowerX 返回业务失败时抛出的异常。
    /// </summary>
    public sealed class WebpowerXApiException : Exception
    {
        /// <summary>
        /// 构造一个包含业务码和追踪信息的异常。
        /// </summary>
        public WebpowerXApiException(int code, string? message, string? responseId = null, string? traceNumber = null)
            : base(message ?? "Unknown WebpowerX API error.")
        {
            Code = code;
            ResponseId = responseId;
            TraceNumber = traceNumber;
        }

        /// <summary>
        /// 业务错误码。
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// 本次响应标识。
        /// </summary>
        public string? ResponseId { get; }

        /// <summary>
        /// 链路追踪号。
        /// </summary>
        public string? TraceNumber { get; }
    }
}
