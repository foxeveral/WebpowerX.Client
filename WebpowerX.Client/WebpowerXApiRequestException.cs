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
        public WebpowerXApiRequestException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
