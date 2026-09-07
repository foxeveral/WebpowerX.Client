using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示标签分页列表项。
    /// </summary>
    public sealed class LabelInfo
    {
        /// <summary>
        /// 标签序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 标签名称。
        /// </summary>
        [JsonPropertyName("labelName")]
        public string? LabelName { get; set; }

        /// <summary>
        /// 联系人数量。
        /// </summary>
        [JsonPropertyName("contactCount")]
        public int ContactCount { get; set; }

        /// <summary>
        /// 更新时间。
        /// </summary>
        [JsonPropertyName("updateDate")]
        public string? UpdateDate { get; set; }

        /// <summary>
        /// 隐藏状态，0 表示不隐藏，1 表示隐藏。
        /// </summary>
        [JsonPropertyName("isConceal")]
        public int IsConceal { get; set; }

        /// <summary>
        /// 标签内部数值标识；接口当前会返回，后续调用仍应使用 sn。
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }
    }
}
