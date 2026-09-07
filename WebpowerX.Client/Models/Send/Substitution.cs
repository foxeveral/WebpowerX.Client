using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// Enjoy 模板的业务数据对象；模板通过 substitutionObj.data.* 读取字段，可用于 #if、#for 和 ??。
    /// </summary>
    public sealed class Substitution
    {
        /// <summary>
        /// 客户自定义业务数据；key 为模板中引用的字段名，value 支持字符串、数字、布尔、对象和数组。
        /// </summary>
        [JsonPropertyName("data")]
        public Dictionary<string, object?>? Data { get; set; }
    }
}
