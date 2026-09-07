using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 更新联系人字段请求参数。
    /// </summary>
    public sealed class EditContactFieldRequest
    {
        /// <summary>
        /// 联系人字段的显示名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 字段英文名称，应符合接口规定的命名格式。
        /// </summary>
        [JsonPropertyName("nameEn")]
        public string NameEn { get; set; } = string.Empty;

        /// <summary>
        /// 字段允许的最大长度。
        /// </summary>
        [JsonPropertyName("attrLength")]
        public int AttrLength { get; set; }

        /// <summary>
        /// 字段中文含义，供管理后台和文档展示。
        /// </summary>
        [JsonPropertyName("meaning")]
        public string Meaning { get; set; } = string.Empty;

        /// <summary>
        /// 需要更新的联系人自定义字段序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string Sn { get; set; } = string.Empty;
    }
}
