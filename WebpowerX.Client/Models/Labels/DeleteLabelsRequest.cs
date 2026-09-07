using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 批量删除标签请求参数。
    /// </summary>
    public sealed class DeleteLabelsRequest
    {
        /// <summary>
        /// 标签序列号集合，数组中的每个元素代表一个标签。
        /// </summary>
        [JsonPropertyName("labelSns")]
        public List<string> LabelSns { get; set; } = new List<string>();
    }
}
