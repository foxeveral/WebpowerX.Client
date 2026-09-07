using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 编辑标签请求参数。
    /// </summary>
    public sealed class EditLabelRequest
    {
        /// <summary>
        /// 标签序列号，用于定位一个标签。
        /// </summary>
        [JsonPropertyName("labelSn")]
        public string LabelSn { get; set; } = string.Empty;

        /// <summary>
        /// 更新后的标签名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
