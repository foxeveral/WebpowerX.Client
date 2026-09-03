namespace WebpowerX.Client
{
    /// <summary>
    /// WebpowerX 接口调用所需的基础配置。
    /// </summary>
    public sealed class WebpowerXApiOptions
    {
        /// <summary>
        /// 服务端地址。默认指向亚洲生产环境。
        /// </summary>
        public string BaseUrl { get; set; } = WebpowerXApiEnvironments.AsiaProduction;

        /// <summary>
        /// 文档中要求放在请求头里的 access-key。
        /// </summary>
        public string AccessKey { get; set; } = string.Empty;

        /// <summary>
        /// 用于生成 access-sign 的密钥。
        /// </summary>
        public string AccessKeySecret { get; set; } = string.Empty;
    }
}
