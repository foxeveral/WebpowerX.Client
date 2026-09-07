using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 邮件正文、摘要或纯文本备用内容。
    /// </summary>
    public sealed class EmailContent
    {
        /// <summary>
        /// 内容类型，常见值是 html 或 plain。
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// 真正提交给接口的文本内容。
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
