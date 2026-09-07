using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 获取发件域名接口的查询参数。
    /// </summary>
    public sealed class GetDomainQuery
    {
        /// <summary>
        /// 发件域名，支持模糊查询；不传时返回全部可用发件域名。
        /// </summary>
        [JsonPropertyName("domain")]
        public string? Domain { get; set; }
    }
}
