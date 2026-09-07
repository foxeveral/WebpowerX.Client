using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台创建或更新联系人字段后的返回结果。
    /// </summary>
    public sealed class ContactFieldUpsertResult
    {
        /// <summary>
        /// 联系人字段序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 联系人字段英文标识。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }
    }
}
