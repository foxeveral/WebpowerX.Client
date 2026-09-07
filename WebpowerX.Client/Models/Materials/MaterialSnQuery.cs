using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 邮件素材序列号查询参数。
    /// </summary>
    public sealed class MaterialSnQuery
    {
        /// <summary>
        /// 邮件素材序列号。
        /// </summary>
        [JsonPropertyName("materialSn")]
        public string MaterialSn { get; set; } = string.Empty;
    }
}
