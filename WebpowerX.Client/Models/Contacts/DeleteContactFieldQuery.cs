using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 删除联系人字段查询参数。
    /// </summary>
    public sealed class DeleteContactFieldQuery
    {
        /// <summary>
        /// 联系人自定义字段序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string Sn { get; set; } = string.Empty;
    }
}
