using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示邮件发送报告。
    /// </summary>
    public sealed class EmailReport
    {
        /// <summary>
        /// 发送任务标识。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string? SendTaskId { get; set; }

        /// <summary>
        /// 邮件被打开的总次数；同一收件人多次打开会重复计数。
        /// </summary>
        [JsonPropertyName("totalOpen")]
        public long TotalOpen { get; set; }

        /// <summary>
        /// 去重后的邮件打开数量。
        /// </summary>
        [JsonPropertyName("uniqueOpen")]
        public long UniqueOpen { get; set; }

        /// <summary>
        /// 邮件中链接被点击的总次数；重复点击会重复计数。
        /// </summary>
        [JsonPropertyName("totalClick")]
        public long TotalClick { get; set; }

        /// <summary>
        /// 去重后的邮件链接点击数量。
        /// </summary>
        [JsonPropertyName("uniqueClick")]
        public long UniqueClick { get; set; }

        /// <summary>
        /// 去重后的硬退信数量。
        /// </summary>
        [JsonPropertyName("hardBounces")]
        public long HardBounces { get; set; }

        /// <summary>
        /// 去重后的软退信数量。
        /// </summary>
        [JsonPropertyName("softBounces")]
        public long SoftBounces { get; set; }

        /// <summary>
        /// 垃圾邮件投诉事件数量。
        /// </summary>
        [JsonPropertyName("spamcomplaints")]
        public long SpamComplaints { get; set; }

        /// <summary>
        /// 重新订阅事件数量。
        /// </summary>
        [JsonPropertyName("resubscribe")]
        public long Resubscribe { get; set; }

        /// <summary>
        /// 点击打开率，按去重点击数除以去重打开数计算；例如 0.25 表示 25%。
        /// </summary>
        [JsonPropertyName("click2OpenRate")]
        public double Click2OpenRate { get; set; }

        /// <summary>
        /// 发送总数。
        /// </summary>
        [JsonPropertyName("totalSent")]
        public long TotalSent { get; set; }

        /// <summary>
        /// 送达总数。
        /// </summary>
        [JsonPropertyName("totalAccepted")]
        public long TotalAccepted { get; set; }

        /// <summary>
        /// 退订事件数量。
        /// </summary>
        [JsonPropertyName("unsubscribes")]
        public long Unsubscribes { get; set; }
    }
}
