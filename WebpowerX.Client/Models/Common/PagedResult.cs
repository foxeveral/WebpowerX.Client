using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台返回的通用分页结果。
    /// </summary>
    /// <typeparam name="T">列表项类型。</typeparam>
    public sealed class PagedResult<T>
    {
        /// <summary>
        /// 总页数。
        /// </summary>
        [JsonPropertyName("totalPage")]
        public int TotalPage { get; set; }

        /// <summary>
        /// 满足条件的总记录数。
        /// </summary>
        [JsonPropertyName("totalRow")]
        public long TotalRow { get; set; }

        /// <summary>
        /// 当前页的业务结果列表。
        /// </summary>
        [JsonPropertyName("resultList")]
        public List<T>? Items { get; set; }
    }
}
