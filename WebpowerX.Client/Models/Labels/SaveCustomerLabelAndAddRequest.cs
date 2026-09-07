using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 添加标签到联系人请求参数。
    /// </summary>
    public sealed class SaveCustomerLabelAndAddRequest
    {
        /// <summary>
        /// 客户侧联系人唯一标识。
        /// </summary>
        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; } = string.Empty;

        /// <summary>
        /// 待添加的标签序列号集合。
        /// </summary>
        [JsonPropertyName("sns")]
        public List<string> Sns { get; set; } = new List<string>();
    }
}
