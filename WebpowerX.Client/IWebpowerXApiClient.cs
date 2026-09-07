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
        /// 发送单封事务邮件，适合验证码、密码重置、订单状态等需要及时处理的业务通知。
        /// </summary>
        /// <param name="request">单封邮件发送请求，包含发件地址、主题、正文、单个收件人和可选的 Enjoy 业务数据。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c> 和 <c>sendTaskId</c>。</returns>
        Task<ApiResponse<SendResult>> SendTransEmailAsync(SingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 发送单封普通邮件，适合单个收件人的普通业务邮件。
        /// </summary>
        /// <param name="request">单封邮件发送请求，包含发件地址、主题、正文、单个收件人和可选的 Enjoy 业务数据。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c> 和 <c>sendTaskId</c>。</returns>
        Task<ApiResponse<SendResult>> SendEmailAsync(SingleEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 批量发送普通邮件，单次最多 1000 人；每个收件人的扩展字段相互独立，通过普通 {$field} 占位符完成个性化，不支持 Enjoy 业务数据。
        /// </summary>
        /// <param name="request">批量邮件发送请求，包含发件地址、主题、正文和收件人数组。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c> 和 <c>sendTaskId</c>。</returns>
        Task<ApiResponse<SendResult>> SendBulkEmailsAsync(BulkEmailRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建个性化发送任务；本接口只创建任务并返回任务标识，随后使用 <see cref="SendWithinPersonalizedTaskAsync" /> 逐封提交邮件。
        /// </summary>
        /// <param name="request">创建个性化任务的请求参数，仅发件地址序列号必填。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>sendTaskId</c> 和 <c>sendTaskName</c>。</returns>
        Task<ApiResponse<SendTaskCreateResult>> CreatePersonalizedTaskAsync(CreatePersonalizedTaskRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建固定模板发送任务，适合正文或素材固定、后续持续提交收件人的场景。
        /// </summary>
        /// <param name="request">创建固定模板任务的请求参数；发件地址和主题必填，正文与素材序列号至少提供一个。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>sendTaskId</c> 和 <c>sendTaskName</c>。</returns>
        Task<ApiResponse<SendTaskCreateResult>> CreateTemplateTaskAsync(CreateTemplateTaskRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 在已创建的个性化任务下提交一封邮件。
        /// </summary>
        /// <param name="request">个性化任务发送请求，包含任务标识、主题、正文、单个收件人和可选的 Enjoy 业务数据。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c>。</returns>
        Task<ApiResponse<SendResult>> SendWithinPersonalizedTaskAsync(SendWithinPersonalizedTaskRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 在已创建的固定模板任务下提交单个收件人的发送请求。
        /// </summary>
        /// <param name="request">固定模板任务单封发送请求，包含任务标识、单个收件人和可选的 Enjoy 业务数据。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c>。</returns>
        Task<ApiResponse<SendResult>> SendWithinTemplateTaskAsync(SendWithinTemplateTaskRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 在已创建的固定模板任务下批量提交多个收件人的发送请求。
        /// </summary>
        /// <param name="request">固定模板任务批量发送请求，包含任务标识和收件人数组，单次最多 1000 人。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>responseId</c>。</returns>
        Task<ApiResponse<SendResult>> SendWithinTemplateTaskToEmailsAsync(SendWithinTemplateTaskToEmailsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 使用公网 CSV 云文件和自定义内容创建发送任务。
        /// </summary>
        /// <param name="request">云文件任务创建请求，包含发件地址、主题、正文和远程收件人文件信息。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>sendTaskId</c> 和 <c>sendTaskName</c>。</returns>
        Task<ApiResponse<SendTaskCreateResult>> CreateCloudFileRecipientTaskAsync(CreateCloudFileTaskRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 使用公网 CSV 云文件和已有邮件素材创建发送任务。
        /// </summary>
        /// <param name="request">云文件素材任务创建请求，包含发件地址、主题、素材序列号和远程收件人文件信息。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>接口受理结果，成功时通常包含 <c>sendTaskId</c> 和 <c>sendTaskName</c>。</returns>
        Task<ApiResponse<SendTaskCreateResult>> CreateCloudFileRecipientTaskFromMaterialAsync(CreateCloudFileTaskFromMaterialRequest request, CancellationToken cancellationToken = default);

        #endregion

        #region 发件基础配置

        /// <summary>
        /// 获取发件域名。
        /// </summary>
        /// <param name="domain">要查询的发件域名。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>发件域名列表结果。</returns>
        Task<ApiResponse<ResultList<DomainInfo>>> GetDomainAsync(DomainQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取发件域名可用的邮件通道。
        /// </summary>
        /// <param name="request">邮件通道查询参数，必须包含发件域名序列号。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件通道列表结果。</returns>
        Task<ApiResponse<ResultList<EmailRouteInfo>>> GetEmailRouteOverDomainAsync(EmailRouteOverDomainQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建发件地址。
        /// </summary>
        /// <param name="request">创建发件地址请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>发件地址列表结果。</returns>
        Task<ApiResponse<ResultList<SenderAddressInfo>>> CreateSenderAsync(CreateSenderRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取发件地址。
        /// </summary>
        /// <param name="request">可选查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>发件地址列表结果。</returns>
        Task<ApiResponse<ResultList<SenderAddressInfo>>> GetSenderAsync(SenderQuery? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取回复地址。
        /// </summary>
        /// <param name="request">可选查询参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>回复地址列表结果。</returns>
        Task<ApiResponse<ResultList<ReplyAddressInfo>>> GetReplyAddressAsync(ReplyAddressQuery? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 新增或更新回复地址。
        /// </summary>
        /// <param name="request">新增或更新回复地址请求参数，字段以 WebpowerX 开放平台文档为准。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> SaveOrUpdateReplyAddressAsync(SaveOrUpdateReplyAddressRequest request, CancellationToken cancellationToken = default);

        #endregion

        #region 联系人管理

        /// <summary>
        /// 获取联系人分页列表。
        /// </summary>
        /// <param name="request">联系人分页查询参数，包含字段检索、应用范围、分页和排序条件。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人分页结果。</returns>
        Task<ApiResponse<PagedResult<ContactInfo>>> ContactPageListAsync(ContactPageListQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取联系人属性。
        /// </summary>
        /// <param name="request">联系人定位参数，支持 customerId 或 name/value 两种方式。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人属性结果列表。</returns>
        Task<ApiResponse<ResultList<ContactAttributeValue>>> ContactCustomerDetailsAsync(ContactIdentityQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取联系人字段详情。
        /// </summary>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人字段结果列表。</returns>
        Task<ApiResponse<ResultList<ContactFieldDetail>>> ContactFieldDetailsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取联系人标签列表。
        /// </summary>
        /// <param name="request">联系人定位参数，支持 customerId 或 name/value 两种方式。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人标签结构。</returns>
        Task<ApiResponse<ContactLabelListResult>> ContactLabelListAsync(ContactIdentityQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取标签下联系人分页列表。
        /// </summary>
        /// <param name="request">标签下联系人分页查询参数，包含标签序列号和分页条件。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签下联系人分页结果。</returns>
        Task<ApiResponse<PagedResult<ContactInfo>>> ContactByLabelPageListAsync(ContactByLabelPageQuery request, CancellationToken cancellationToken = default);

        #endregion

        #region 联系人属性管理

        /// <summary>
        /// 创建联系人属性。
        /// </summary>
        /// <param name="request">创建联系人属性请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人字段创建结果。</returns>
        Task<ApiResponse<ContactFieldUpsertResult>> CreateContactFieldAsync(CreateContactFieldRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 更新联系人属性。
        /// </summary>
        /// <param name="request">更新联系人属性请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> EditContactFieldAsync(EditContactFieldRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除联系人属性。
        /// </summary>
        /// <param name="request">删除联系人属性查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> DeleteContactFieldAsync(DeleteContactFieldQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取联系人属性列表。
        /// </summary>
        /// <param name="request">联系人属性分页查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>联系人字段定义分页结果。</returns>
        Task<ApiResponse<PagedResult<ContactFieldInfo>>> FindContactFieldAsync(ContactFieldPageQuery? request = null, CancellationToken cancellationToken = default);

        #endregion

        #region 标签管理

        /// <summary>
        /// 创建标签。
        /// </summary>
        /// <param name="request">创建标签请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签创建结果。</returns>
        Task<ApiResponse<LabelUpsertResult>> CreateLabelAsync(CreateLabelRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 编辑标签。
        /// </summary>
        /// <param name="request">编辑标签请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签更新结果。</returns>
        Task<ApiResponse<LabelUpsertResult>> EditLabelAsync(EditLabelRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除标签。
        /// </summary>
        /// <param name="request">批量删除标签请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> DeleteLabelAsync(DeleteLabelsRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取标签分页列表。
        /// </summary>
        /// <param name="request">标签分页查询参数，包含分组过滤、关键字、分页和排序条件。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签分页结果。</returns>
        Task<ApiResponse<PagedResult<LabelInfo>>> LabelPageListAsync(LabelPageQuery? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取标签分组列表。
        /// </summary>
        /// <param name="request">标签分组排序查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签分组结果列表。</returns>
        Task<ApiResponse<ResultList<LabelGroupInfo>>> LabelGroupListAsync(LabelGroupListQuery? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建标签分组。
        /// </summary>
        /// <param name="request">创建标签分组请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签分组创建结果。</returns>
        Task<ApiResponse<LabelGroupUpsertResult>> CreateLabelGroupAsync(CreateLabelGroupRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 编辑标签分组。
        /// </summary>
        /// <param name="request">编辑标签分组请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>标签分组更新结果。</returns>
        Task<ApiResponse<LabelGroupUpsertResult>> EditLabelGroupAsync(EditLabelGroupRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除标签分组。
        /// </summary>
        /// <param name="request">删除标签分组查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> DeleteLabelGroupAsync(DeleteLabelGroupQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 更改联系人的标签。
        /// </summary>
        /// <param name="request">更改联系人标签请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> ChangeCustomerLabelAsync(ChangeCustomerLabelRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 添加标签到联系人。
        /// </summary>
        /// <param name="request">添加联系人标签请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>添加后的联系人标签状态列表。</returns>
        Task<ApiResponse<ResultList<CustomerLabelAddResult>>> SaveCustomerLabelAndAddAsync(SaveCustomerLabelAndAddRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除联系人的标签。
        /// </summary>
        /// <param name="request">删除联系人标签查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> DeleteCustomerLabelAsync(DeleteCustomerLabelQuery request, CancellationToken cancellationToken = default);

        #endregion

        #region 内容素材管理

        /// <summary>
        /// 获取素材分组列表。
        /// </summary>
        /// <param name="request">素材分组列表查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>素材分组结果列表。</returns>
        Task<ApiResponse<ResultList<MaterialGroupInfo>>> GroupListAsync(MaterialGroupListQuery? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建素材分组。
        /// </summary>
        /// <param name="request">创建素材分组请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>素材分组创建结果。</returns>
        Task<ApiResponse<MaterialGroupUpsertResult>> CreateMaterialGroupAsync(CreateMaterialGroupRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 编辑素材分组。
        /// </summary>
        /// <param name="request">编辑素材分组请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>素材分组更新结果。</returns>
        Task<ApiResponse<MaterialGroupUpsertResult>> EditMaterialGroupAsync(EditMaterialGroupRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除素材分组。
        /// </summary>
        /// <param name="request">删除素材分组查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> DeleteMaterialGroupAsync(DeleteMaterialGroupQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取邮件素材分页列表。
        /// </summary>
        /// <param name="request">邮件素材分页查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件素材分页结果。</returns>
        Task<ApiResponse<PagedResult<MaterialInfo>>> EmailMaterialPageListAsync(EmailMaterialPageQuery? request = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取邮件素材详情。
        /// </summary>
        /// <param name="request">邮件素材序列号查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件素材详情。</returns>
        Task<ApiResponse<MaterialDetails>> EmailMaterialDetailsAsync(MaterialSnQuery request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 创建邮件素材。
        /// </summary>
        /// <param name="request">创建邮件素材请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件素材创建结果。</returns>
        Task<ApiResponse<MaterialUpsertResult>> CreateMaterialAsync(CreateMaterialRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 编辑邮件素材。
        /// </summary>
        /// <param name="request">编辑邮件素材请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件素材更新结果。</returns>
        Task<ApiResponse<MaterialUpsertResult>> EditMaterialAsync(EditMaterialRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 删除邮件素材。
        /// </summary>
        /// <param name="request">邮件素材序列号查询参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>空结果。</returns>
        Task<ApiResponse<EmptyResult>> DeleteMaterialAsync(MaterialSnQuery request, CancellationToken cancellationToken = default);

        #endregion

        #region 数据统计

        /// <summary>
        /// 获取邮件报告数据。
        /// </summary>
        /// <param name="request">邮件报告查询请求参数。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件报告结果。</returns>
        Task<ApiResponse<EmailReport>> GetEmailReportAsync(EmailReportRequest request, CancellationToken cancellationToken = default);

        /// <summary>
        /// 获取事件记录查询结果。
        /// </summary>
        /// <param name="request">事件记录查询请求参数，包含事件类型、发送任务标识和分页条件。</param>
        /// <param name="cancellationToken">取消当前异步请求的令牌。</param>
        /// <returns>邮件事件记录列表。</returns>
        Task<ApiResponse<List<EmailEventRecord>>> GetStatisticsDataTypeAsync(EventRecordQuery request, CancellationToken cancellationToken = default);

        #endregion
    }
}
