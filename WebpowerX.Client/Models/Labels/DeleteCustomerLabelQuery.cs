using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 删除联系人标签查询参数。
    /// </summary>
    public sealed class DeleteCustomerLabelQuery
    {
        /// <summary>
        /// 客户侧联系人唯一标识。
        /// </summary>
        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// 需要从联系人移除的标签序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string Sn { get; set; } = string.Empty;
    }
}
