using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 邮件附件信息。
    /// </summary>
    public sealed class EmailAttachment
    {
        /// <summary>
        /// 附件展示给收件人的文件名。
        /// </summary>
        [JsonPropertyName("fileName")]
        public string? FileName { get; set; }

        /// <summary>
        /// 服务端可直接访问的公网下载地址。
        /// </summary>
        [JsonPropertyName("fileUrl")]
        public string? FileUrl { get; set; }

        /// <summary>
        /// 可选的文件后缀类型。
        /// </summary>
        [JsonPropertyName("fileType")]
        public string? FileType { get; set; }

        /// <summary>
        /// 可选的 MIME 类型。
        /// </summary>
        [JsonPropertyName("mimeType")]
        public string? MimeType { get; set; }
    }
}
