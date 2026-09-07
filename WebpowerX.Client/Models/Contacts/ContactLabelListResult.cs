using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示联系人标签列表结果。
    /// </summary>
    public sealed class ContactLabelListResult
    {
        /// <summary>
        /// 联系人普通标签列表。
        /// </summary>
        [JsonPropertyName("customerLabelList")]
        public List<LabelSimpleInfo>? CustomerLabelList { get; set; }

        /// <summary>
        /// 微信粉丝标签列表。
        /// </summary>
        [JsonPropertyName("fansLabelList")]
        public List<FansLabelGroup>? FansLabelList { get; set; }
    }
}
