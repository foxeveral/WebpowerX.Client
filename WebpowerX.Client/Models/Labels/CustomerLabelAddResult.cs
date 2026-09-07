using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示添加联系人标签后的标签状态。
    /// </summary>
    public sealed class CustomerLabelAddResult
    {
        /// <summary>
        /// 显示或隐藏状态，0 表示显示，1 表示隐藏。
        /// </summary>
        [JsonPropertyName("isConceal")]
        public int IsConceal { get; set; }

        /// <summary>
        /// 标签序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }
    }
}
