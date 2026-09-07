using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台回复地址信息。
    /// </summary>
    public sealed class ReplyAddressInfo
    {
        /// <summary>
        /// 回复地址名称。
        /// </summary>
        [JsonPropertyName("replyName")]
        public string? ReplyName { get; set; }

        /// <summary>
        /// 回复邮箱。
        /// </summary>
        [JsonPropertyName("replyEmail")]
        public string? ReplyEmail { get; set; }

        /// <summary>
        /// 回复地址序列号。
        /// </summary>
        [JsonPropertyName("replySn")]
        public string? ReplySn { get; set; }
    }
}
