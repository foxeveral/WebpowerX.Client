using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 创建标签分组请求参数。
    /// </summary>
    public sealed class CreateLabelGroupRequest
    {
        /// <summary>
        /// 父分组序列号；不传表示顶层或默认父级。
        /// </summary>
        [JsonPropertyName("parentGroupSn")]
        public string? ParentGroupSn { get; set; }

        /// <summary>
        /// 标签分组名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
