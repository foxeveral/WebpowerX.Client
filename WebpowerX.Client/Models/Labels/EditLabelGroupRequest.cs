using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 编辑标签分组请求参数。
    /// </summary>
    public sealed class EditLabelGroupRequest
    {
        /// <summary>
        /// 父分组序列号；不传表示保持当前父级或使用默认父级。
        /// </summary>
        [JsonPropertyName("parentGroupSn")]
        public string? ParentGroupSn { get; set; }

        /// <summary>
        /// 更新后的标签分组名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 需要更新的标签分组序列号。
        /// </summary>
        [JsonPropertyName("groupSn")]
        public string GroupSn { get; set; } = string.Empty;
    }
}
