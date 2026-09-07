using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台返回的通用列表结果。
    /// </summary>
    /// <typeparam name="T">列表项类型。</typeparam>
    public sealed class ResultList<T>
    {
        /// <summary>
        /// 当前查询条件下的业务结果列表。
        /// </summary>
        [JsonPropertyName("resultList")]
        public List<T>? Items { get; set; }
    }
}
