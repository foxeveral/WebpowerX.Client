using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 远程收件人文件对象；云文件任务必须提供，CSV 列名可作为普通 {$field} 占位符的数据源。
    /// </summary>
    public sealed class RecipientCloudFile
    {
        /// <summary>
        /// 收件人文件的公网下载 URL；必须保证服务端可直接访问。
        /// </summary>
        [JsonPropertyName("cloudFileUrl")]
        public string CloudFileUrl { get; set; } = string.Empty;

        /// <summary>
        /// 调用方声明的文件收件人总数，用于目标数量和进度；应与文件实际有效行数一致。
        /// </summary>
        [JsonPropertyName("recipientTotalCount")]
        public int RecipientTotalCount { get; set; }

        /// <summary>
        /// 文件压缩格式；支持 zip/gzip，未压缩时不传。
        /// </summary>
        [JsonPropertyName("archiveType")]
        public string? ArchiveType { get; set; }

        /// <summary>
        /// 文件内容格式；当前只支持 csv，不传时默认 csv。
        /// </summary>
        [JsonPropertyName("fileType")]
        public string? FileType { get; set; }

        /// <summary>
        /// CSV 字符编码，例如 UTF-8 或 GBK；不传时默认 UTF-8。
        /// </summary>
        [JsonPropertyName("fileEncoding")]
        public string? FileEncoding { get; set; }
    }
}
