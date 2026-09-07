using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示联系人属性值。
    /// </summary>
    public sealed class ContactAttributeValue
    {
        /// <summary>
        /// 联系人字段的英文标识。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }

        /// <summary>
        /// 联系人属性值；类型取决于该字段定义，可能是字符串、数字、布尔值、数组或对象。
        /// </summary>
        [JsonPropertyName("value")]
        public object? Value { get; set; }

        /// <summary>
        /// 联系人属性展示名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
