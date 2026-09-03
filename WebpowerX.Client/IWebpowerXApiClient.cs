using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebpowerX.Client.Models;

namespace WebpowerX.Client
{
    /// <summary>
    /// WebpowerX 客户端抽象，适合通过依赖注入直接消费。
    /// </summary>
    public interface IWebpowerXApiClient
    {
        #region 邮件发送接口

        /// <summary>
        /// 发送单封事务邮件，适合验证码、密码重置、订单状态等单收件人通知场景。
        /// </summary>
        /// <param name="request">单封邮件发送请求。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c> 和 <c>sendTaskId</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendSingleTransactionalEmailAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 发送单封普通邮件，适合单个收件人的普通业务邮件。
        /// </summary>
        /// <param name="request">单封邮件发送请求。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c> 和 <c>sendTaskId</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendSingleEmailAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 批量发送普通邮件，适合同一主题和正文发送给多个收件人的场景。
        /// </summary>
        /// <param name="request">批量邮件发送请求。具体收件人集合字段以接口文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c> 和 <c>sendTaskId</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendBulkEmailsAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建个性化发送任务，适合每位收件人的主题或正文不同、但需要统一任务报告的场景。
        /// </summary>
        /// <param name="request">创建个性化任务的请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>sendTaskId</c> 和 <c>sendTaskName</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskCreationResult>> CreatePersonalizedTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建固定模板发送任务，适合正文或素材固定、后续持续提交收件人的场景。
        /// </summary>
        /// <param name="request">创建固定模板任务的请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>sendTaskId</c> 和 <c>sendTaskName</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskCreationResult>> CreateTemplateTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 在已创建的个性化任务下提交一封邮件。
        /// </summary>
        /// <param name="request">个性化任务发送请求，通常需要包含 <c>sendTaskId</c> 和收件人个性化内容。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendWithinPersonalizedTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 在已创建的固定模板任务下提交单个收件人的发送请求。
        /// </summary>
        /// <param name="request">固定模板任务发送请求，通常需要包含 <c>sendTaskId</c> 和收件人替换数据。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendWithinTemplateTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 在已创建的固定模板任务下批量提交多个收件人的发送请求。
        /// </summary>
        /// <param name="request">固定模板任务批量发送请求。具体收件人集合字段以接口文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskResponse>> SendWithinTemplateTaskToEmailsAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 使用公网 CSV 云文件和自定义内容创建发送任务。
        /// </summary>
        /// <param name="request">云文件任务创建请求，云文件地址和字段映射以接口文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>sendTaskId</c> 和 <c>sendTaskName</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskCreationResult>> CreateCloudFileRecipientTaskAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 使用公网 CSV 云文件和已有邮件素材创建发送任务。
        /// </summary>
        /// <param name="request">云文件素材任务创建请求，素材编号、云文件地址和字段映射以接口文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>sendTaskId</c> 和 <c>sendTaskName</c>。</returns>
        Task<WebpowerXApiResponse<WebpowerXSendTaskCreationResult>> CreateCloudFileRecipientTaskFromMaterialAsync(WebpowerXSingleEmailRequest request, CancellationToken cancellationToken = default);

        #endregion

        #region 发件基础配置

        /// <summary>
        /// 获取发件域名。
        /// </summary>
        /// <param name="domain">要查询的发件域名。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>发件域名列表结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXDomainInfo>>> GetDomainAsync(string domain, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取发件域名可用的邮件通道。
        /// </summary>
        /// <param name="domain">要查询邮件通道的发件域名。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件通道列表结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXEmailRouteInfo>>> GetEmailRouteOverDomainAsync(string domain, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建发件地址。
        /// </summary>
        /// <param name="request">创建发件地址请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>发件地址列表结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXSenderAddressInfo>>> CreateSenderAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取发件地址。
        /// </summary>
        /// <param name="request">可选查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>发件地址列表结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXSenderAddressInfo>>> GetSenderAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取回复地址。
        /// </summary>
        /// <param name="request">可选查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>回复地址列表结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXReplyAddressInfo>>> GetReplyAddressAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 新增或更新回复地址。
        /// </summary>
        /// <param name="request">新增或更新回复地址请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> SaveOrUpdateReplyAddressAsync(object request, CancellationToken cancellationToken = default);

        #endregion

        #region 联系人管理

        /// <summary>
        /// 获取联系人分页列表。
        /// </summary>
        /// <param name="request">可选分页和筛选参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人分页结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXContactInfo>>> ContactPageListAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取联系人属性。
        /// </summary>
        /// <param name="request">联系人属性查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人属性结果列表。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXContactAttributeValue>>> ContactCustomerDetailsAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取联系人字段详情。
        /// </summary>
        /// <param name="request">联系人字段详情查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人字段结果列表。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXContactFieldDetail>>> ContactFieldDetailsAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取联系人标签列表。
        /// </summary>
        /// <param name="request">可选查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人标签结构。</returns>
        Task<WebpowerXApiResponse<WebpowerXContactLabelListResponse>> ContactLabelListAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取标签下联系人分页列表。
        /// </summary>
        /// <param name="request">可选标签、分页和筛选参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签下联系人分页结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXContactInfo>>> ContactByLabelPageListAsync(object? request = null, CancellationToken cancellationToken = default);

        #endregion

        #region 联系人属性管理

        /// <summary>
        /// 创建联系人属性。
        /// </summary>
        /// <param name="request">创建联系人属性请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人字段创建结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXContactFieldUpsertResult>> CreateContactFieldAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 更新联系人属性。
        /// </summary>
        /// <param name="request">更新联系人属性请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> EditContactFieldAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除联系人属性。
        /// </summary>
        /// <param name="request">删除联系人属性请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteContactFieldAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取联系人属性列表。
        /// </summary>
        /// <param name="request">联系人属性列表查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人字段定义分页结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXContactFieldInfo>>> FindContactFieldAsync(object request, CancellationToken cancellationToken = default);

        #endregion

        #region 标签管理

        /// <summary>
        /// 创建标签。
        /// </summary>
        /// <param name="request">创建标签请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签创建结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXLabelUpsertResult>> CreateLabelAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 编辑标签。
        /// </summary>
        /// <param name="request">编辑标签请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签更新结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXLabelUpsertResult>> EditLabelAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除标签。
        /// </summary>
        /// <param name="request">删除标签请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteLabelAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取标签分页列表。
        /// </summary>
        /// <param name="request">可选分页和筛选参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签分页结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXLabelInfo>>> LabelPageListAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取标签分组列表。
        /// </summary>
        /// <param name="request">可选查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签分组结果列表。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXLabelGroupInfo>>> LabelGroupListAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建标签分组。
        /// </summary>
        /// <param name="request">创建标签分组请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签分组创建结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXLabelGroupUpsertResult>> CreateLabelGroupAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 编辑标签分组。
        /// </summary>
        /// <param name="request">编辑标签分组请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签分组更新结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXLabelGroupUpsertResult>> EditLabelGroupAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除标签分组。
        /// </summary>
        /// <param name="request">删除标签分组请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteLabelGroupAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 更改联系人的标签。
        /// </summary>
        /// <param name="request">更改联系人标签请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> ChangeCustomerLabelAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 添加标签到联系人。
        /// </summary>
        /// <param name="request">添加联系人标签请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>添加后的联系人标签状态列表。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXCustomerLabelAddResult>>> SaveCustomerLabelAndAddAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除联系人的标签。
        /// </summary>
        /// <param name="request">删除联系人标签请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteCustomerLabelAsync(object request, CancellationToken cancellationToken = default);

        #endregion

        #region 内容素材管理

        /// <summary>
        /// 获取素材分组列表。
        /// </summary>
        /// <param name="request">可选查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>素材分组结果列表。</returns>
        Task<WebpowerXApiResponse<WebpowerXResultListResponse<WebpowerXMaterialGroupInfo>>> GroupListAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建素材分组。
        /// </summary>
        /// <param name="request">创建素材分组请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>素材分组创建结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXMaterialGroupUpsertResult>> CreateMaterialGroupAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 编辑素材分组。
        /// </summary>
        /// <param name="request">编辑素材分组请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>素材分组更新结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXMaterialGroupUpsertResult>> EditMaterialGroupAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除素材分组。
        /// </summary>
        /// <param name="request">删除素材分组请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteMaterialGroupAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取邮件素材分页列表。
        /// </summary>
        /// <param name="request">可选分页和筛选参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件素材分页结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXPagedResponse<WebpowerXMaterialInfo>>> EmailMaterialPageListAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取邮件素材详情。
        /// </summary>
        /// <param name="request">邮件素材详情查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件素材详情。</returns>
        Task<WebpowerXApiResponse<WebpowerXMaterialDetails>> EmailMaterialDetailsAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建邮件素材。
        /// </summary>
        /// <param name="request">创建邮件素材请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件素材创建结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXMaterialUpsertResult>> CreateMaterialAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 编辑邮件素材。
        /// </summary>
        /// <param name="request">编辑邮件素材请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件素材更新结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXMaterialUpsertResult>> EditMaterialAsync(object request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除邮件素材。
        /// </summary>
        /// <param name="request">删除邮件素材请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmptyResult>> DeleteMaterialAsync(object request, CancellationToken cancellationToken = default);

        #endregion

        #region 数据统计

        /// <summary>
        /// 获取邮件报告数据。
        /// </summary>
        /// <param name="request">可选报表查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件报告结果。</returns>
        Task<WebpowerXApiResponse<WebpowerXEmailReport>> GetEmailReportAsync(object? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取事件记录查询结果。
        /// </summary>
        /// <param name="request">可选事件查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件事件记录列表。</returns>
        Task<WebpowerXApiResponse<List<WebpowerXEmailEventRecord>>> GetStatisticsDataTypeAsync(object? request = null, CancellationToken cancellationToken = default);

        #endregion
    }
}
