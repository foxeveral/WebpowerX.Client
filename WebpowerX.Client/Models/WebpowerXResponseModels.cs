using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebpowerX.Client.Models
{
    /// <summary>
    /// 表示开放平台没有额外业务数据的成功结果。
    /// </summary>
    public sealed class WebpowerXEmptyResult
    {
    }

    /// <summary>
    /// 表示开放平台返回的通用列表结果。
    /// </summary>
    /// <typeparam name="T">列表项类型。</typeparam>
    public sealed class WebpowerXResultListResponse<T>
    {
        /// <summary>
        /// 当前查询条件下的业务结果列表。
        /// </summary>
        [JsonPropertyName("resultList")]
        public List<T>? ResultList { get; set; }
    }

    /// <summary>
    /// 表示开放平台返回的通用分页结果。
    /// </summary>
    /// <typeparam name="T">列表项类型。</typeparam>
    public sealed class WebpowerXPagedResponse<T>
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
        public List<T>? ResultList { get; set; }
    }

    /// <summary>
    /// 表示开放平台发件域名信息。
    /// </summary>
    public sealed class WebpowerXDomainInfo
    {
        /// <summary>
        /// 发件域名序列号。
        /// </summary>
        [JsonPropertyName("domainSn")]
        public string? DomainSn { get; set; }

        /// <summary>
        /// 发件域名。
        /// </summary>
        [JsonPropertyName("domain")]
        public string? Domain { get; set; }

        /// <summary>
        /// 文档示例未固定描述的扩展字段。
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object?>? AdditionalProperties { get; set; }
    }

    /// <summary>
    /// 表示开放平台邮件通道信息。
    /// </summary>
    public sealed class WebpowerXEmailRouteInfo
    {
        /// <summary>
        /// 邮件通道序列号。
        /// </summary>
        [JsonPropertyName("emailRouteSn")]
        public string? EmailRouteSn { get; set; }

        /// <summary>
        /// 邮件通道名称。
        /// </summary>
        [JsonPropertyName("emailRouteName")]
        public string? EmailRouteName { get; set; }

        /// <summary>
        /// 文档示例未固定描述的扩展字段。
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object?>? AdditionalProperties { get; set; }
    }

    /// <summary>
    /// 表示开放平台发件地址信息。
    /// </summary>
    public sealed class WebpowerXSenderAddressInfo
    {
        /// <summary>
        /// 发件地址序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 发件地址序列号，兼容文档示例中的字段名。
        /// </summary>
        [JsonPropertyName("senderAddressSn")]
        public string? SenderAddressSn { get; set; }

        /// <summary>
        /// 发件邮箱。
        /// </summary>
        [JsonPropertyName("fromEmail")]
        public string? FromEmail { get; set; }

        /// <summary>
        /// 发件域名序列号。
        /// </summary>
        [JsonPropertyName("domainSn")]
        public string? DomainSn { get; set; }

        /// <summary>
        /// 邮件通道序列号。
        /// </summary>
        [JsonPropertyName("emailRouteSn")]
        public string? EmailRouteSn { get; set; }
    }

    /// <summary>
    /// 表示开放平台创建或更新联系人字段后的返回结果。
    /// </summary>
    public sealed class WebpowerXContactFieldUpsertResult
    {
        /// <summary>
        /// 联系人字段序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 联系人字段英文标识。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }
    }

    /// <summary>
    /// 表示开放平台回复地址信息。
    /// </summary>
    public sealed class WebpowerXReplyAddressInfo
    {
        /// <summary>
        /// 回复地址名称。
        /// </summary>
        [JsonPropertyName("replyName")]
        public string? ReplyName { get; set; }

        /// <summary>
        /// 回复邮箱。
        /// </summary>
        [JsonPropertyName("replyEmail")]
        public string? ReplyEmail { get; set; }

        /// <summary>
        /// 回复地址序列号。
        /// </summary>
        [JsonPropertyName("replySn")]
        public string? ReplySn { get; set; }
    }

    /// <summary>
    /// 表示联系人属性值。
    /// </summary>
    public sealed class WebpowerXContactAttributeValue
    {
        /// <summary>
        /// 联系人字段的英文标识。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }

        /// <summary>
        /// 联系人属性值。
        /// </summary>
        [JsonPropertyName("value")]
        public object? Value { get; set; }

        /// <summary>
        /// 联系人属性展示名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    /// <summary>
    /// 表示联系人字段详情。
    /// </summary>
    public sealed class WebpowerXContactFieldDetail
    {
        /// <summary>
        /// 联系人字段的英文标识。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }

        /// <summary>
        /// 联系人字段序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 联系人字段展示名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 是否允许作为查询条件。
        /// </summary>
        [JsonPropertyName("searchType")]
        public bool SearchType { get; set; }

        /// <summary>
        /// 是否允许作为排序字段。
        /// </summary>
        [JsonPropertyName("sortType")]
        public bool SortType { get; set; }
    }

    /// <summary>
    /// 表示联系人标签列表结果。
    /// </summary>
    public sealed class WebpowerXContactLabelListResponse
    {
        /// <summary>
        /// 联系人普通标签列表。
        /// </summary>
        [JsonPropertyName("customerLabelList")]
        public List<WebpowerXLabelSimpleInfo>? CustomerLabelList { get; set; }

        /// <summary>
        /// 微信粉丝标签列表。
        /// </summary>
        [JsonPropertyName("fansLabelList")]
        public List<WebpowerXFansLabelGroup>? FansLabelList { get; set; }
    }

    /// <summary>
    /// 表示标签基础信息。
    /// </summary>
    public sealed class WebpowerXLabelSimpleInfo
    {
        /// <summary>
        /// 标签或业务对象名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 标签或业务对象序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }
    }

    /// <summary>
    /// 表示开放平台创建或更新标签后的返回结果。
    /// </summary>
    public sealed class WebpowerXLabelUpsertResult
    {
        /// <summary>
        /// 标签序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 标签名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 标签内部数值标识。
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }
    }

    /// <summary>
    /// 表示添加联系人标签后的标签状态。
    /// </summary>
    public sealed class WebpowerXCustomerLabelAddResult
    {
        /// <summary>
        /// 显示或隐藏状态，0 表示显示，1 表示隐藏。
        /// </summary>
        [JsonPropertyName("isConceal")]
        public int IsConceal { get; set; }

        /// <summary>
        /// 标签序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }
    }

    /// <summary>
    /// 表示开放平台创建或更新标签分组后的返回结果。
    /// </summary>
    public sealed class WebpowerXLabelGroupUpsertResult
    {
        /// <summary>
        /// 标签分组序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 标签分组名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    /// <summary>
    /// 表示某个公众号下的粉丝标签分组。
    /// </summary>
    public sealed class WebpowerXFansLabelGroup
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
        public List<WebpowerXLabelSimpleInfo>? FansLabelInfoList { get; set; }
    }

    /// <summary>
    /// 表示联系人字段定义。
    /// </summary>
    public sealed class WebpowerXContactFieldInfo
    {
        /// <summary>
        /// 联系人字段序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 联系人字段的英文标识。
        /// </summary>
        [JsonPropertyName("fieldName")]
        public string? FieldName { get; set; }

        /// <summary>
        /// 联系人属性的业务含义说明。
        /// </summary>
        [JsonPropertyName("meaning")]
        public string? Meaning { get; set; }

        /// <summary>
        /// 联系人属性的字段英文标识候选值。
        /// </summary>
        [JsonPropertyName("nameEn")]
        public string? NameEn { get; set; }

        /// <summary>
        /// 字段数据类型。
        /// </summary>
        [JsonPropertyName("attrGenre")]
        public int AttrGenre { get; set; }

        /// <summary>
        /// 联系人属性允许的最大长度。
        /// </summary>
        [JsonPropertyName("attrLength")]
        public int AttrLength { get; set; }

        /// <summary>
        /// 联系人字段的最后更新时间。
        /// </summary>
        [JsonPropertyName("updateTime")]
        public string? UpdateTime { get; set; }

        /// <summary>
        /// 联系人字段的创建时间。
        /// </summary>
        [JsonPropertyName("createTime")]
        public string? CreateTime { get; set; }

        /// <summary>
        /// 是否为主键字段。
        /// </summary>
        [JsonPropertyName("pk")]
        public bool Pk { get; set; }

        /// <summary>
        /// 是否为系统预置字段。
        /// </summary>
        [JsonPropertyName("preset")]
        public bool Preset { get; set; }
    }

    /// <summary>
    /// 表示联系人分页列表项。
    /// </summary>
    public sealed class WebpowerXContactInfo
    {
        /// <summary>
        /// 联系人唯一标识。
        /// </summary>
        [JsonPropertyName("customerId")]
        public string? CustomerId { get; set; }

        /// <summary>
        /// 联系人邮箱。
        /// </summary>
        [JsonPropertyName("邮箱")]
        public string? Email { get; set; }

        /// <summary>
        /// 联系人名称。
        /// </summary>
        [JsonPropertyName("联系人名称")]
        public string? Name { get; set; }

        /// <summary>
        /// 联系人手机号。
        /// </summary>
        [JsonPropertyName("手机号")]
        public string? Mobile { get; set; }

        /// <summary>
        /// 联系人微信字段值。
        /// </summary>
        [JsonPropertyName("微信")]
        public string? WeChat { get; set; }

        /// <summary>
        /// 联系人导入时间。
        /// </summary>
        [JsonPropertyName("导入时间")]
        public string? ImportTime { get; set; }

        /// <summary>
        /// 联系人最后更新时间。
        /// </summary>
        [JsonPropertyName("更新时间")]
        public string? UpdateTime { get; set; }

        /// <summary>
        /// 企业自定义联系人字段。
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object?>? AdditionalProperties { get; set; }
    }

    /// <summary>
    /// 表示标签分页列表项。
    /// </summary>
    public sealed class WebpowerXLabelInfo
    {
        /// <summary>
        /// 标签序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 标签名称。
        /// </summary>
        [JsonPropertyName("labelName")]
        public string? LabelName { get; set; }

        /// <summary>
        /// 联系人数量。
        /// </summary>
        [JsonPropertyName("contactCount")]
        public int ContactCount { get; set; }

        /// <summary>
        /// 更新时间。
        /// </summary>
        [JsonPropertyName("updateDate")]
        public string? UpdateDate { get; set; }

        /// <summary>
        /// 隐藏状态，0 表示不隐藏，1 表示隐藏。
        /// </summary>
        [JsonPropertyName("isConceal")]
        public int IsConceal { get; set; }

        /// <summary>
        /// 标签内部数值标识。
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }
    }

    /// <summary>
    /// 表示标签分组信息。
    /// </summary>
    public sealed class WebpowerXLabelGroupInfo
    {
        /// <summary>
        /// 标签分组序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 标签分组名称。
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [JsonPropertyName("createDate")]
        public string? CreateDate { get; set; }

        /// <summary>
        /// 父分组序列号。
        /// </summary>
        [JsonPropertyName("parentSn")]
        public string? ParentSn { get; set; }
    }

    /// <summary>
    /// 表示素材分组信息。
    /// </summary>
    public sealed class WebpowerXMaterialGroupInfo
    {
        /// <summary>
        /// 素材分组序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材分组名称。
        /// </summary>
        [JsonPropertyName("groupName")]
        public string? GroupName { get; set; }

        /// <summary>
        /// 创建人名称。
        /// </summary>
        [JsonPropertyName("createName")]
        public string? CreateName { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [JsonPropertyName("createDate")]
        public string? CreateDate { get; set; }

        /// <summary>
        /// 最后更新人名称。
        /// </summary>
        [JsonPropertyName("updateName")]
        public string? UpdateName { get; set; }

        /// <summary>
        /// 最后更新时间。
        /// </summary>
        [JsonPropertyName("updateDate")]
        public string? UpdateDate { get; set; }

        /// <summary>
        /// 分组内的素材数量。
        /// </summary>
        [JsonPropertyName("count")]
        public string? Count { get; set; }
    }

    /// <summary>
    /// 表示开放平台创建或更新素材分组后的返回结果。
    /// </summary>
    public sealed class WebpowerXMaterialGroupUpsertResult
    {
        /// <summary>
        /// 素材分组序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材分组名称。
        /// </summary>
        [JsonPropertyName("materialGroupName")]
        public string? MaterialGroupName { get; set; }
    }

    /// <summary>
    /// 表示邮件素材列表项。
    /// </summary>
    public sealed class WebpowerXMaterialInfo
    {
        /// <summary>
        /// 邮件素材序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材名称。
        /// </summary>
        [JsonPropertyName("materialName")]
        public string? MaterialName { get; set; }

        /// <summary>
        /// 创建人名称。
        /// </summary>
        [JsonPropertyName("createName")]
        public string? CreateName { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [JsonPropertyName("createDate")]
        public string? CreateDate { get; set; }

        /// <summary>
        /// 最后更新人名称。
        /// </summary>
        [JsonPropertyName("updateName")]
        public string? UpdateName { get; set; }

        /// <summary>
        /// 最后更新时间。
        /// </summary>
        [JsonPropertyName("updateDate")]
        public string? UpdateDate { get; set; }

        /// <summary>
        /// 素材正文类型。
        /// </summary>
        [JsonPropertyName("materialType")]
        public string? MaterialType { get; set; }
    }

    /// <summary>
    /// 表示邮件素材详情。
    /// </summary>
    public sealed class WebpowerXMaterialDetails
    {
        /// <summary>
        /// 邮件素材序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材名称。
        /// </summary>
        [JsonPropertyName("materialName")]
        public string? MaterialName { get; set; }

        /// <summary>
        /// 素材的邮件正文。
        /// </summary>
        [JsonPropertyName("materialContent")]
        public string? MaterialContent { get; set; }

        /// <summary>
        /// 创建人名称。
        /// </summary>
        [JsonPropertyName("createName")]
        public string? CreateName { get; set; }

        /// <summary>
        /// 创建时间。
        /// </summary>
        [JsonPropertyName("createDate")]
        public string? CreateDate { get; set; }

        /// <summary>
        /// 最后更新人名称。
        /// </summary>
        [JsonPropertyName("updateName")]
        public string? UpdateName { get; set; }

        /// <summary>
        /// 最后更新时间。
        /// </summary>
        [JsonPropertyName("updateDate")]
        public string? UpdateDate { get; set; }

        /// <summary>
        /// 素材正文类型。
        /// </summary>
        [JsonPropertyName("materialType")]
        public string? MaterialType { get; set; }

        /// <summary>
        /// 素材预览地址。
        /// </summary>
        [JsonPropertyName("previewUrl")]
        public string? PreviewUrl { get; set; }

        /// <summary>
        /// 素材测试主题。
        /// </summary>
        [JsonPropertyName("testSubject")]
        public string? TestSubject { get; set; }
    }

    /// <summary>
    /// 表示开放平台创建或更新素材后的返回结果。
    /// </summary>
    public sealed class WebpowerXMaterialUpsertResult
    {
        /// <summary>
        /// 素材序列号。
        /// </summary>
        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        /// <summary>
        /// 素材预览地址。
        /// </summary>
        [JsonPropertyName("previewUrl")]
        public string? PreviewUrl { get; set; }
    }

    /// <summary>
    /// 表示邮件发送报告。
    /// </summary>
    public sealed class WebpowerXEmailReport
    {
        /// <summary>
        /// 发送任务标识。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string? SendTaskId { get; set; }

        /// <summary>
        /// 邮件被打开的总次数。
        /// </summary>
        [JsonPropertyName("totalOpen")]
        public long TotalOpen { get; set; }

        /// <summary>
        /// 去重后的邮件打开数量。
        /// </summary>
        [JsonPropertyName("uniqueOpen")]
        public long UniqueOpen { get; set; }

        /// <summary>
        /// 邮件中链接被点击的总次数。
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
        /// 点击打开率。
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

    /// <summary>
    /// 表示邮件事件记录。
    /// </summary>
    public sealed class WebpowerXEmailEventRecord
    {
        /// <summary>
        /// 事件类型。
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// 相关联系人或事件对应的邮箱地址。
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// 事件发生时间，Unix 秒级时间戳。
        /// </summary>
        [JsonPropertyName("eventTs")]
        public long EventTs { get; set; }

        /// <summary>
        /// 点击事件对应的原始链接。
        /// </summary>
        [JsonPropertyName("clickUrl")]
        public string? ClickUrl { get; set; }
    }

    /// <summary>
    /// 表示开放平台创建发送任务后的返回结果。
    /// </summary>
    public sealed class WebpowerXSendTaskCreationResult
    {
        /// <summary>
        /// 发送任务标识。
        /// </summary>
        [JsonPropertyName("sendTaskId")]
        public string? SendTaskId { get; set; }

        /// <summary>
        /// 发送任务名称。
        /// </summary>
        [JsonPropertyName("sendTaskName")]
        public string? SendTaskName { get; set; }
    }
}
