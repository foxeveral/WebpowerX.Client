using System;

namespace WebpowerX.Client
{
    /// <summary>
    /// HTTP 层或者序列化层失败时抛出的异常。
    /// </summary>
    public sealed class WebpowerXApiRequestException : Exception
    {
        /// <summary>
        /// 构造请求异常。
        /// </summary>
        public WebpowerXApiRequestException(string message, Exception? innerException = null, int? statusCode = null)
            : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// HTTP 状态码；网络层失败而没有拿到响应时为 null。
        /// </summary>
        public int? StatusCode { get; }
    }
}
