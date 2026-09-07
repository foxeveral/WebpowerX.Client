using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示联系人字段定义。
    /// </summary>
    public sealed class ContactFieldInfo
    {
        /// <summary>
        /// 联系人字段序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 联系人字段的英文标识。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }

        /// <summary>
        /// 联系人属性的业务含义说明。
        /// </summary>
        [JsonPropertyName("meaning")]
        public string? Meaning { get; set; }

        /// <summary>
        /// 联系人属性的字段英文标识候选值。
        /// </summary>
        [JsonPropertyName("nameEn")]
        public string? NameEn { get; set; }

        /// <summary>
        /// 字段数据类型。
        /// </summary>
        [JsonPropertyName("attrGenre")]
        public int AttrGenre { get; set; }

        /// <summary>
        /// 联系人属性允许的最大长度。
        /// </summary>
        [JsonPropertyName("attrLength")]
        public int AttrLength { get; set; }

        /// <summary>
        /// 联系人字段的最后更新时间。
        /// </summary>
        [JsonPropertyName("updateTime")]
        public string? UpdateTime { get; set; }

        /// <summary>
        /// 联系人字段的创建时间。
        /// </summary>
        [JsonPropertyName("createTime")]
        public string? CreateTime { get; set; }

        /// <summary>
        /// 是否为主键字段。
        /// </summary>
        [JsonPropertyName("pk")]
        public bool Pk { get; set; }

        /// <summary>
        /// 是否为系统预置字段。
        /// </summary>
        [JsonPropertyName("preset")]
        public bool Preset { get; set; }
    }
}
