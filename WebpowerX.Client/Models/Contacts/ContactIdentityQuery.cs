using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 联系人定位查询参数，支持 customerId 或 name/value 两种方式。
    /// </summary>
    public sealed class ContactIdentityQuery
    {
        /// <summary>
        /// 联系人标识；传入后不要再传 <see cref="Name" /> 和 <see cref="Value" />。
        /// </summary>
        [JsonPropertyName("customerId")]
        public string? CustomerId { get; set; }

        /// <summary>
        /// 用于定位联系人的查询字段名，应使用联系人字段详情中允许搜索的字段；需与 <see cref="Value" /> 同时传入。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 与 <see cref="Name" /> 对应的查询字段值。
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
