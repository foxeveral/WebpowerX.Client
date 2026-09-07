using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示邮件事件记录。
    /// </summary>
    public sealed class EmailEventRecord
    {
        /// <summary>
        /// 事件类型。
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// 相关联系人或事件对应的邮箱地址。
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// 事件发生时间，Unix 秒级时间戳。
        /// </summary>
        [JsonPropertyName("eventTs")]
        public long EventTs { get; set; }

        /// <summary>
        /// 点击事件对应的原始链接；非点击事件可能为空。
        /// </summary>
        [JsonPropertyName("clickUrl")]
        public string? ClickUrl { get; set; }
    }
}
