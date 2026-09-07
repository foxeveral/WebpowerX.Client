using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 新增或更新回复地址接口的请求参数。
    /// </summary>
    public sealed class SaveOrUpdateReplyAddressRequest
    {
        /// <summary>
        /// 实际接收回复邮件的邮箱地址。
        /// </summary>
        [JsonPropertyName("replyEmail")]
        public string ReplyEmail { get; set; } = string.Empty;

        /// <summary>
        /// 回复地址的展示名称。
        /// </summary>
        [JsonPropertyName("replyName")]
        public string ReplyName { get; set; } = string.Empty;

        /// <summary>
        /// 回复地址序列号；不传时创建回复地址，传入时更新该回复地址。
        /// </summary>
        [JsonPropertyName("replyAddressSn")]
        public string? ReplyAddressSn { get; set; }
    }
}
