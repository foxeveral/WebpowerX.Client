using System;

namespace WebpowerX.Client.Internal
{
    /// <summary>
    /// 接口地址相关的内部工具。
    /// </summary>
    internal static class UrlHelper
    {
        /// <summary>
        /// 保证 BaseUrl 以 / 结尾，方便后续拼接相对路径。
        /// </summary>
        public static string NormalizeBaseUrl(string baseUrl)
            => baseUrl.EndsWith("/", StringComparison.Ordinal) ? baseUrl : baseUrl + "/";
    }
}
