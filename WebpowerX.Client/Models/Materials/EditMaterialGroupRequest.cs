using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 编辑素材分组请求参数。
    /// </summary>
    public sealed class EditMaterialGroupRequest
    {
        /// <summary>
        /// 需要更新的素材分组序列号。
        /// </summary>
        [JsonPropertyName("materialGroupSn")]
        public string MaterialGroupSn { get; set; } = string.Empty;

        /// <summary>
        /// 父分组序列号，用于建立分组层级。
        /// </summary>
        [JsonPropertyName("parentGroupSn")]
        public string? ParentGroupSn { get; set; }

        /// <summary>
        /// 素材分组名称，用于列表展示和运营识别。
        /// </summary>
        [JsonPropertyName("materialGroupName")]
        public string MaterialGroupName { get; set; } = string.Empty;
    }
}
