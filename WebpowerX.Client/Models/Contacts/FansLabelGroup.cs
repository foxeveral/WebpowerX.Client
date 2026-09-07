using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示某个公众号下的粉丝标签分组。
    /// </summary>
    public sealed class FansLabelGroup
    {
        /// <summary>
        /// 微信公众号 AppID。
        /// </summary>
        [JsonPropertyName("appid")]
        public string? AppId { get; set; }

        /// <summary>
        /// 该公众号下的粉丝标签列表。
        /// </summary>
        [JsonPropertyName("fansLabelInfoList")]
        public List<LabelSimpleInfo>? FansLabelInfoList { get; set; }
    }
}
