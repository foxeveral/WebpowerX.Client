using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 更改联系人标签请求参数。
    /// </summary>
    public sealed class ChangeCustomerLabelRequest
    {
        /// <summary>
        /// 客户侧联系人唯一标识。
        /// </summary>
        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// 变更前的标签序列号。
        /// </summary>
        [JsonPropertyName("oldSn")]
        public string OldSn { get; set; } = string.Empty;

        /// <summary>
        /// 变更后的标签序列号。
        /// </summary>
        [JsonPropertyName("newSn")]
        public string NewSn { get; set; } = string.Empty;
    }
}
